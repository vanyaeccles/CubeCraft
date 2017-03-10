using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_lose_popwnd : MonoBehaviour {
    public UIHandler uiHandler;
    public Button tryAgainButton;
    public Button backButton;
    public GameObject losePanel;
	// Use this for initialization
	void Start () {
        tryAgainButton.onClick.AddListener(processTryAgainEvent);
        tryAgainButton.onClick.AddListener(processBackEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void processBackEvent()
    {

    }

    void processTryAgainEvent()
    {

    }

    public  void hide()
    {
        losePanel.SetActive(false);
    }
      public  void show()
    {
        losePanel.SetActive(true);
    }
}
