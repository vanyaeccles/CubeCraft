using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Cube;
//using Judge;
public class UIHandler : MonoBehaviour {
    

 //   public GameObject MenuPanel;
    public GameObject TimerPanel;
    public GameObject ConfirmPanel;
    public GameObject WinPanel;
    public GameObject DynamicPanel;
    // GrubMode, TildMOde are subPanel of DynamicPanel
    public GameObject GrabMode;
    public GameObject TileMode;

    public Button RestartButton;
    public Button ConfirmButton;
    public Button CancelButton;
    public Button BackButton;
    public Button WinBackButton;
    public Button WinRestartButton;
    public Button WinContinueButton;

    public Button GrabButton;
    public Button ReleaseButton;
    public Button AddButton;
    public Button DeleteButton;

    //Timer
    //public Text timerText;
    private float startTime;
    private bool finished = false;

    //refactor
    public Widget_timer timer;
    public Widget_dynamic_menu dynamicMenu;
    public Widget_static_menu staticMenu;
    public Widget_win_popup winPopWnd;
    public Widget_restart_confirm_popwnd confirmPopWnd;


    void initWidget()
    {
        timer.uiHandler = this;
        dynamicMenu.uiHandler = this;
        staticMenu.uiHandler = this;
        winPopWnd.uiHandler = this;
        confirmPopWnd.uiHandler = this;
    }
    //-refactor


        

    // Use this for initialization
    void Start () {
        //refactor
        initWidget();
        //-refactor

        //Initialise timer
        //timerText = GameObject.Find("TimerText").GetComponent<Text>();//@TODO change to find with tag
        startTime = Time.time;


        //  MenuPanel = GameObject.Find("MenuPanel");
        TimerPanel = GameObject.Find("TimerPanel");
        ConfirmPanel = GameObject.Find("ConfirmPanel");
        WinPanel = GameObject.Find("WinPanel");
        DynamicPanel = GameObject.Find("DynamicPanel");
        GrabMode = GameObject.Find("GrabMode");
        TileMode = GameObject.Find("TileMode");

        CancelButton = GameObject.Find("CancelButton").GetComponent<Button>();
        BackButton = GameObject.Find("BackButton").GetComponent<Button>();
        ConfirmButton = GameObject.Find("ConfirmButton").GetComponent<Button>();
        RestartButton = GameObject.Find("RestartButton").GetComponent<Button>();
       

        WinBackButton = GameObject.Find("WinBackButton").GetComponent<Button>();
        WinRestartButton = GameObject.Find("WinRestartButton").GetComponent<Button>();
        WinContinueButton = GameObject.Find("WinContinueButton").GetComponent<Button>();

        GrabButton = GameObject.Find("GrabButton").GetComponent<Button>();
        ReleaseButton = GameObject.Find("ReleaseButton").GetComponent<Button>();

        AddButton = GameObject.Find("CreateNewButton").GetComponent<Button>();
        DeleteButton = GameObject.Find("DeleteButton").GetComponent<Button>();

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

        GrabButton.onClick.AddListener(GameObject.Find("Player Controlled Cube").GetComponent<Movement>().GrabRelease);
        ReleaseButton.onClick.AddListener(GameObject.Find("Player Controlled Cube").GetComponent<Movement>().GrabRelease);

        AddButton.onClick.AddListener(GameObject.Find("Player Controlled Cube").GetComponent<Movement>().AddDelete);
        DeleteButton.onClick.AddListener(GameObject.Find("Player Controlled Cube").GetComponent<Movement>().AddDelete);
    }

    void InitialiseUI()
    {
        ShutDownAll();

        //MenuPanel.SetActive(true);
        TimerPanel.SetActive(true);
        // ConfirmPanel.SetActive(false);
        confirmPopWnd.hide();
        dynamicMenu.init();
    }

    //DeActivates all UI elements
    void ShutDownAll()
    {
      //  MenuPanel.SetActive(false);
        TimerPanel.SetActive(false);
        ConfirmPanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    void RestartPress()
    {
        ShutDownAll();
        Debug.Log("???");
        ConfirmPanel.SetActive(true);
    }

    void ConfirmPress()
    {
        ShutDownAll();
        // InitialiseUI();
        //GameObject.Find("Player Controlled Cube").GetComponent<Timer>().Start();
        SceneManager.LoadScene("GameplayScene");

        //GameObject.Find("Player Controlled Cube").GetComponent<Timer>().Start();
        //GameObject.Find("Player Controlled Cube").GetComponent<Timer>().SetFinished(false);

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
        //Timer related
        if (finished)
            return;

        UpdateTimer();
    }


    private void UpdateTimer()
    {
        //amount of time since timer started (in seconds)
        int t = (int)(Time.time - startTime);

        string minutes = (t / 60).ToString();
        // limits float to "fx" decimal places
        string seconds = (t % 60).ToString("f0");

        if (t % 60 < 10)
            seconds = "0" + seconds;

        timer.SetTime(minutes, seconds);
    }
    public void Finish()
    {
        finished = true;
        //timerText.color = Color.yellow;
    }
    public void SetFinished(bool flag)
    {
        finished = flag;
    }




    public void switch2GrubMode()
    {
        GrabMode.SetActive(true);
        TileMode.SetActive(false);
    }
    public void switch2TileMode()
    {
        GrabMode.SetActive(false);
        TileMode.SetActive(true);
    }

    public void switch2TileModeAdd()
    {
        return;
        switch2TileMode();
        AddButton.GetComponentInChildren<Text>().text = "ADD";
    }

    public void switch2TileModeDelete()
    {
        switch2TileMode();
        AddButton.GetComponentInChildren<Text>().text = "DELETE";
    }
}
