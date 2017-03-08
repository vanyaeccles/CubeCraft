using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_restart_confirm_popwnd : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject confirmPanel;
    public Button confirmButton;
    public Button cancelButton;

	// Use this for initialization
	void Start () {
        confirmButton.onClick.AddListener(processConfirmEvent);
        cancelButton.onClick.AddListener(processCancelEvent);
	}
	

    public void show()
    {
        confirmPanel.SetActive(true);
    }

    public void hide()
    {
        confirmPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}

    void processConfirmEvent()
    {
        uiHandler.ConfirmPress();
    }
    void processCancelEvent()
    {
        uiHandler.CancelPress();
    }
}
