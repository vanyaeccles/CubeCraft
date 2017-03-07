using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Cube;
public class SolutionChecker : MonoBehaviour {

    public Vector3 correct;
    public Vector3 playerAnswer;

    string timeScore;

	// Use this for initialization
	void Start () {
        correct = new Vector3(2.0f,.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Player = GameObject.Find("Player Controlled Cube");
        Movement movement = Player.GetComponent<Movement>();
        playerAnswer = movement.GetPosition();


        if (Input.GetKeyDown(KeyCode.H))
        {
          
            if (playerAnswer == correct)
            {
                timeScore = GameObject.Find("TimerText").GetComponent<Text>().text;

                Debug.Log("Correct Solution! Time: " + timeScore);
                //Tell the timer to stop
                SendMessage("Finish");
                GameObject.Find("UIController").GetComponent<UIHandler>().winPopWnd.show();
            }
            else
            {
                Debug.Log("Try again!");
            }
            checkSolution();
        }
    }



    void checkSolution()
    {
        if (playerAnswer == correct)
        {
            timeScore = GameObject.Find("TimerText").GetComponent<Text>().text;

            Debug.Log("Correct Solution! Time: " + timeScore);
            //Tell the timer to stop
            SendMessage("Finish");
        }
        else
        {
            Debug.Log("Try again!");
        }
    }
}
