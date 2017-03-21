﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_timer_ProbScene : MonoBehaviour {

    public UIHandler_ProbScene uiHandler;
    public GameObject panel;
    public Text timer_text;
    public Image time_bar;

    float second;

    // Use this for initialization
    void Start()
    {
        //timer_text.material.color = Color.black;

        time_bar.fillAmount = 1.0f;

        second = 1.0f / 30;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CountDown()
    {
        time_bar.fillAmount -= second;

        Debug.Log("Tick");
        // When the countdown bar reaches zero, check the solution
        //if (time_bar.fillAmount == 0.0f)
            //uiHandler.CheckPress();

    }


    public void setTimerText(string text)
    {
        timer_text.text = text;
    }

    public void SetTime(string minutes, string seconds)
    {
        timer_text.text = minutes + ":" + seconds;
    }


    public void SetTimerTextRed()
    {
        //timer_text.material.color = Color.white;
    }
}
