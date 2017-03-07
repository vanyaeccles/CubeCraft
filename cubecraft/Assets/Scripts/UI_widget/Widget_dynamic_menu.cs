using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_dynamic_menu : MonoBehaviour {
    public UIHandler uiHandler;
    public GameObject tilemode_panel;
    public GameObject grabmode_panel;
    public Button createNewButton;
    public Button grabButton;
    public Button deleteButton;
    public Button releaseButton;

	// Use this for initialization
	void Start () {
        createNewButton.onClick.AddListener(processCreateNewEvent);
        grabButton.onClick.AddListener(processGrabEvent);
        deleteButton.onClick.AddListener(processDeleteEvent);
        releaseButton.onClick.AddListener(processReleaseEvent);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   public  void init()
    {
        grabmode_panel.SetActive(false);
        tilemode_panel.SetActive(true);
    }

   
    void processCreateNewEvent()
    {

    }
    void processGrabEvent()
    {

    }
    void processDeleteEvent()
    {

    }
    void processReleaseEvent()
    {

    }
}
