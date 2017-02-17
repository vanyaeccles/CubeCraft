using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIHandler : MonoBehaviour {


    public GameObject MenuPanel;
    public GameObject TimerPanel;
    public GameObject ConfirmPanel;


    public Button RestartButton;
    public Button ConfirmButton;
    public Button CancelButton;
    public Button BackButton;
    


    // Use this for initialization
    void Start () {

        MenuPanel = GameObject.Find("MenuPanel");
        TimerPanel = GameObject.Find("TimerPanel");
        ConfirmPanel = GameObject.Find("ConfirmPanel");

        InitialiseUI();


        //Buttons
        Button restartbtn = RestartButton.GetComponent<Button>();
        Button confirmbtn = ConfirmButton.GetComponent<Button>();
        Button cancelbtn = CancelButton.GetComponent<Button>();
        Button backbtn = BackButton.GetComponent<Button>();



        restartbtn.onClick.AddListener(RestartPress);
        confirmbtn.onClick.AddListener(ConfirmPress);
        cancelbtn.onClick.AddListener(CancelPress);
        backbtn.onClick.AddListener(BackPress);
    }

    void InitialiseUI()
    {
        ShutDownAll();

        MenuPanel.SetActive(true);
        TimerPanel.SetActive(true);
        ConfirmPanel.SetActive(false);
    }

    //DeActivates all UI elements
    void ShutDownAll()
    {
        MenuPanel.SetActive(false);
        TimerPanel.SetActive(false);
        ConfirmPanel.SetActive(false);
    }

    void RestartPress()
    {
        ShutDownAll();
        ConfirmPanel.SetActive(true);
    }

    void ConfirmPress()
    {
        ShutDownAll();

        //Back to main menu
    }

    void CancelPress()
    {
        ShutDownAll();

        InitialiseUI();
    }

    void BackPress()
    {
        ShutDownAll();

        // Do something else
    }



    // Update is called once per frame
    void Update () {

	}
}
