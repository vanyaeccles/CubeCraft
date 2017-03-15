﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_win_popup : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject winPanel;
    public Button backButton;
    public Button restartButton;
    public Button continueButton;
	// Use this for initialization
	void Start () {
        backButton.onClick.AddListener(processBackEvent);
        restartButton.onClick.AddListener(processRestartEvent);
        continueButton.onClick.AddListener(processContinueEvent);
	}
	public void show()
    {
        winPanel.SetActive(true);
    }
    public void hide()
    {
        winPanel.SetActive(false);

    }


	// Update is called once per frame
	void Update () {
		
	}

    void processBackEvent()
    {
        uiHandler.BackPress();
    }
    void processRestartEvent()
    {
        uiHandler.RestartPress();
    }

    void processContinueEvent()
    {
        uiHandler.CancelPress();
    }
}
