using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIHandler : MonoBehaviour {


    public GameObject MenuPanel;
    public GameObject TimerPanel;
    public GameObject ConfirmPanel;
    public GameObject WinPanel;


    public Button RestartButton;
    public Button ConfirmButton;
    public Button CancelButton;
    public Button BackButton;
    public Button WinBackButton;
    public Button WinRestartButton;
    public Button WinContinueButton;


    // Use this for initialization
    void Start () {

        MenuPanel = GameObject.Find("MenuPanel");
        TimerPanel = GameObject.Find("TimerPanel");
        ConfirmPanel = GameObject.Find("ConfirmPanel");
        WinPanel = GameObject.Find("WinPanel");

        CancelButton = GameObject.Find("CancelButton").GetComponent<Button>();
        BackButton = GameObject.Find("BackButton").GetComponent<Button>();
        ConfirmButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
        RestartButton = GameObject.Find("RestartButton").GetComponent<Button>();

        WinBackButton = GameObject.Find("WinBackButton").GetComponent<Button>();
        WinRestartButton = GameObject.Find("WinRestartButton").GetComponent<Button>();
        WinContinueButton = GameObject.Find("WinContinueButton").GetComponent<Button>();
        


        InitialiseUI();


        ////Buttons
        //Button restartbtn = RestartButton.GetComponent<Button>();
        //Button confirmbtn = ConfirmButton.GetComponent<Button>();
        //Button cancelbtn = CancelButton.GetComponent<Button>();
        //Button backbtn = BackButton.GetComponent<Button>();



        RestartButton.onClick.AddListener(RestartPress);
        ConfirmButton.onClick.AddListener(ConfirmPress);
        CancelButton.onClick.AddListener(CancelPress);
        BackButton.onClick.AddListener(BackPress);

        WinBackButton.onClick.AddListener(BackPress);
        WinRestartButton.onClick.AddListener(RestartPress);
        WinContinueButton.onClick.AddListener(CancelPress);
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
        WinPanel.SetActive(false);
    }

    void RestartPress()
    {
        ShutDownAll();
        ConfirmPanel.SetActive(true);
    }

    void ConfirmPress()
    {
        ShutDownAll();
        // InitialiseUI();
        //GameObject.Find("Player Controlled Cube").GetComponent<Timer>().Start();
        SceneManager.LoadScene("GameplayScene");
        GameObject.Find("Player Controlled Cube").GetComponent<Timer>().Start();
        GameObject.Find("Player Controlled Cube").GetComponent<Timer>().finished = false;

        //Debug.Log("rest");
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
        SceneManager.LoadScene("StartScene");
        // Do something else
    }


    // Update is called once per frame
    void Update () {

	}
}
