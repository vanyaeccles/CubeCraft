using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_timer_ProbScene : MonoBehaviour {

    public UIHandler_ProbScene uiHandler;
    public GameObject panel;
    public Text timer_text;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
        //@TODO this changes the colour of all 'Sprites-Default', dont do it
        //timer_text.material.color = Color.white;
    }
}
