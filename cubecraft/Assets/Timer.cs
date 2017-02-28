using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Judge
{
    /* Timer.cs
     *  This class maintains a timer for the user interface in minutes and seconds
     */

    public class Timer : MonoBehaviour
    {

        private Text timerText;
        private float startTime;
        private bool finished = false;

        // Use this for initialization
        public void Start()
        {
            timerText = GameObject.Find("TimerText").GetComponent<Text>();//@TODO change to find with tag
            startTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            if (finished)
                return;

            UpdateTimer();
        }


        public void Finish()
        {
            finished = true;
            timerText.color = Color.yellow;
        }

        public void SetFinished(bool flag)
        {
            finished = flag;
        }

        private void UpdateTimer()
        {
            //amount of time since timer started (in seconds)
            int t = (int)(Time.time - startTime);

            string minutes = (t / 60).ToString();
            // limits float to "fx" decimal places
            string seconds = (t % 60).ToString("f0");

            if (t % 60 < 10)
                seconds = "0" + seconds;

            timerText.text = minutes + ":" + seconds;
        }

    }
}
