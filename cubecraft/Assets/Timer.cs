using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;
    public bool finished = false;

	// Use this for initialization
	public void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

        if (finished)
            return;

        //amount of time since timer started (in seconds)
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        // limits float to "fx" decimal places
        string seconds = (t % 60).ToString("f0");

        timerText.text = minutes + ":" + seconds;
	}

    public void Finish()
    {
        finished = true;
        timerText.color = Color.yellow;
    }

}
