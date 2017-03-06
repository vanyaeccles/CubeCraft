using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Widget_static_menu : MonoBehaviour {
    public UIHandler uiHandler;
    public Button restartButton;
    public Button backButton;

    // Use this for initialization
    void Start()
    {
        restartButton.onClick.AddListener(processRestartEvent);
        backButton.onClick.AddListener(processBackEvent);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void processRestartEvent()
    {

    }

    void processBackEvent()
    {

    }
}
