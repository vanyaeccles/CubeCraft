﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_layer_operation : MonoBehaviour {
    public GameObject operationPanel;

    public Button moveUpButton;
    public Button moveDownButton;

	// Use this for initialization
	void Start () {
        moveUpButton.onClick.AddListener(processMoveUpEvent);
        moveDownButton.onClick.AddListener(processMoveDownEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void processMoveUpEvent()
    {

    }

    void processMoveDownEvent()
    {

    }
}
