using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour 
{
	Rigidbody2D rb;

	public GameObject Respawn;
	public GameObject Ball;

	public GameObject ScoreParticle;

    public static bool DestoryBall = false;

	public float PosSpeed = 500f;
	public float NegSpeed = -500f;
	public float Force = 20.0f;

	// Use this for initialization
	void Start () 
	{



		rb = GetComponent<Rigidbody2D> ();
        Ball = GameObject.FindGameObjectWithTag("Ball");

		//Flip coin Touch determine direction
		int xDirection = Random.Range(0, 2);

		int yDirection = Random.Range(0, 3);


		Vector2 launchDirection = new Vector2 ();

		if (xDirection == 0) 
		{
			launchDirection.x = NegSpeed;
		}

		if (xDirection == 1) 
		{
			launchDirection.x = PosSpeed;
		}

		if (yDirection == 2) 
		{
			launchDirection.y = 0f;
		}


		//Assign velocity based off where we launch ball
		rb.velocity = launchDirection;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        //		rigidbody.AddForce()

        if (DestoryBall == true)
        {
            StartCoroutine(Destroy());

            DestoryBall = false;
        }
    }

	void OnCollisionEnter (Collision hit)
	{
		if (hit.gameObject.tag == "TopBounds") 
		{
			float speedInXDirection = 0f;

			if (rb.velocity.x > 0f)
				speedInXDirection = 8f;

			if (rb.velocity.x < 0f)
				speedInXDirection = -8f;

			rb.velocity = new Vector2 (speedInXDirection, -8f);
		}

		if (hit.gameObject.tag == "BottomBounds") 
		{
			float speedInXDirection = 0f;

			if (rb.velocity.x > 0f)
				speedInXDirection = 8f;

			if (rb.velocity.x < 0f)
				speedInXDirection = -8f;

			rb.velocity = new Vector2 (speedInXDirection, 8f);
		}


		if (hit.gameObject.tag == "Player") 
		{
            Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(400, 500));
             
			rb.velocity = new Vector2 (-20f, 0f);

			if (transform.position.y - hit.gameObject.transform.position.y < -2) 
			{
				rb.velocity = new Vector2 (-10f, -8f);
			}

			if (transform.position.y - hit.gameObject.transform.position.y > 2) 
			{
				rb.velocity = new Vector2 (-20f, 8f);
			}



			rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * -1f);

			rb.AddForce(transform.right * Force);
		}



    }

		
	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.name == "Goal1" || other.gameObject.tag == "Goal2" || other.gameObject.name == "Goal3" || other.gameObject.name == "Goal4" ) 
		{

			StartCoroutine (Destroy());

		}

    }

	private IEnumerator Destroy()
	{

		yield return new WaitForSecondsRealtime(.2f);

		Instantiate (ScoreParticle, Ball.transform.position, Ball.transform.rotation);

		Destroy (Ball);

	}

		

}
