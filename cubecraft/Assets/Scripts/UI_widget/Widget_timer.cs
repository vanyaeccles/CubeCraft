using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_timer : MonoBehaviour {

    public UIHandler uiHandler;
    public GameObject panel;
    public Text timer_text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void setTimerText(string text)
    {
        timer_text.text = text;
    }

    

}
