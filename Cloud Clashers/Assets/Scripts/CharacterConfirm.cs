using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterConfirm : MonoBehaviour 
{
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (SceneManager.GetActiveScene().name == "Character select")
        {

            if (PlayerSelection.P1Ok == true && PlayerSelectionP2.P2Ok == true)
            {
                FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                FindObjectOfType<AudioManager>().Stop("CharacterSelectTheme");
                SceneManager.LoadScene("Game");
            }

        }

        if (SceneManager.GetActiveScene().name == "4 Player Character select" )
        {

            if (PlayerSelection.P1Ok == true && PlayerSelectionP2.P2Ok == true && PlayerSelectionP3.P3Ok == true && PlayerSelectionP4.P4Ok == true)
            {
                FindObjectOfType<AudioManager>().Stop("MainMenuTheme");
                FindObjectOfType<AudioManager>().Stop("CharacterSelectTheme");
                SceneManager.LoadScene("Game (Four player)");
            }

        }



	}
}
