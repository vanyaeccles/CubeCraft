using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolutionChecker : MonoBehaviour {

    public Vector3 correct;
    public Vector3 playerAnswer;

	// Use this for initialization
	void Start () {
        correct = new Vector3(2.0f,.5f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {

        GameObject Player = GameObject.Find("Player Controlled Cube");
        Movement movement = Player.GetComponent<Movement>();
        playerAnswer = movement.pos;

        if (Input.GetKeyDown(KeyCode.H))
        {
          
            if (playerAnswer == correct)
            {
                Debug.Log("You Win");
            }
            else
            {
                Debug.Log("Try again.");
            }

        }
        }
}
