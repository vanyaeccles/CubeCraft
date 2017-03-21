using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_timer : MonoBehaviour {

    public UIHandler uiHandler;
    public GameObject panel;
    public Text timer_text;
    public Image time_bar;
	// Use this for initialization
	void Start () {

        time_bar.fillAmount = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void setTimerText(string text)
    {
        timer_text.text = text;
    }

    public void SetTime(string minutes, string seconds)
    {
        timer_text.text = minutes + ":" + seconds;
    }

}
