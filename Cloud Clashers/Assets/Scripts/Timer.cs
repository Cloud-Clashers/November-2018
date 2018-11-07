using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour 
{

	public float Overtimex = 500f;
	public float overtimey = -500f;
	public float startingtime = 5;
	public static float Timecounter;


    public bool StartTimer = true;

	private TextMeshProUGUI theText;

    public GameObject Overtime;

    public GameObject Timerp1Round1Win;
	public GameObject Timerp1Round2Win;
	public GameObject Timerp2Round1Win;
	public GameObject Timerp2Round2Win;

    public GameObject P1WinAnimation;
    public GameObject P2WinAnimation;

    int p1score = ScoreManager.scoreP1;
	int p2score = ScoreManager.scoreP2;

	private ScoreManager scoremanager;
    private BallControl BallControl;
    private BallRespawn BallRespawn;

	//public GameObject ballcontroll;


	// Use this for initialization
	void Start () 
	{
        StartCoroutine(Wait());

        theText = GetComponent<TextMeshProUGUI> ();

		scoremanager = GetComponent<ScoreManager> ();

        BallControl = GetComponent<BallControl>();

        BallRespawn = GetComponent<BallRespawn>();

        Timecounter = startingtime;
	}
	
	// Update is called once per frame
	void Update () 
	{
        //var ballcontrollscript = ballcontroll.GetComponent<BallControl> ();

            int p1score = ScoreManager.scoreP1;
            int p2score = ScoreManager.scoreP2;

            Timecounter -= Time.deltaTime;

            theText.text = "" + Mathf.Round(Timecounter);

            if (Timecounter < 1 && ScoreManager.P1win1 == false)
            {

                if (p1score > p2score && ScoreManager.P1win1 == false)
                {

                    Timerp1Round1Win.SetActive(true);

                    ScoreManager.scoreP1 = 0;

                    ScoreManager.scoreP2 = 0;

                    ScoreManager.P1win1 = true;

                    //BallRespawn.OvertimeActive = true;


                    BallControl.DestoryBall = true;

                    BallRespawn.BallDestroyed = true;
                
                    //how to start coroutine from another script?
                    //StartCoroutine(Camera.main.GetComponent<BallRespawn>().Goal());

                    resetTime();

                }

            }

            if (Timecounter < 1 && ScoreManager.P1win1 == true)
            {

                if (p1score > p2score && ScoreManager.P1win1 == true)
                {

                    ScoreManager.P1win2 = true;

                    P1WinAnimation.SetActive(true);

                    BallControl.DestoryBall = true;


                    StartCoroutine(WinTimer());

                    resetTime();

                }
            }

            if (Timecounter < 1 && ScoreManager.P2win1 == false)
            {

                if (p2score > p1score && ScoreManager.P2win1 == false)
                {

                    Timerp2Round1Win.SetActive(true);

                    ScoreManager.scoreP1 = 0;

                    ScoreManager.scoreP2 = 0;

                    ScoreManager.P2win1 = true;

                    //BallRespawn.OvertimeActive = true;

                    BallControl.DestoryBall = true;

                    BallRespawn.BallDestroyed = true;

                    resetTime();

                }
            }

            if (Timecounter < 1 && ScoreManager.P2win1 == true)
            {

                if (p2score > p1score && ScoreManager.P2win1 == true)
                {

                    ScoreManager.P2win2 = true;

                    P2WinAnimation.SetActive(true);

                    BallControl.DestoryBall = true;

                    StartCoroutine(WinTimer());

                    resetTime();

                }
            }

        if (p1score != p2score)
        {

            Overtime.SetActive(false);
        }


        if (Timecounter < 1)
            {
                if (p2score == p1score)
                {
                    Overtime.SetActive(true);
                    theText.text = "   ";


                }

            }


    }

    private IEnumerator WinTimer()
    {

        yield return new WaitForSecondsRealtime(5.0f);

        SceneManager.LoadScene("Main Menu");

    }

    private IEnumerator Wait()
    {
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(5.0f);

        Time.timeScale = 1;

    }

    public void resetTime ()
	{

		Timecounter = startingtime;

	}
}
