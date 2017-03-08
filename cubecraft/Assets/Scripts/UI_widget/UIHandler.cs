using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Cube;
public class UIHandler : MonoBehaviour
{

    private float startTime;
    private bool finished = false;

    //refactor
    public Widget_timer timer;
    public Widget_dynamic_menu dynamicMenu;
    public Widget_static_menu staticMenu;
    public Widget_win_popup winPopWnd;
    public Widget_restart_confirm_popwnd confirmPopWnd;

    private Movement movement;


    void initWidget()
    {
        timer.uiHandler = this;
        dynamicMenu.uiHandler = this;
        staticMenu.uiHandler = this;
        winPopWnd.uiHandler = this;
        confirmPopWnd.uiHandler = this;
    }
    //-refactor


    void Awake()
    {
        movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
    }

    // Use this for initialization
    void Start()
    {
        //refactor
        initWidget();
        //-refactor

        //Initialise timer
        startTime = Time.time;
        InitialiseUI();
    }

    void InitialiseUI()
    {
        ShutDownAll();
        confirmPopWnd.hide();
        dynamicMenu.init();
    }

    //DeActivates all UI elements
    void ShutDownAll()
    {
        confirmPopWnd.hide();
        winPopWnd.hide();
    }

    public void RestartPress()
    {
        ShutDownAll();
        confirmPopWnd.show();
    }

    public void ConfirmPress()
    {
        ShutDownAll();
        //SceneManager.LoadScene("GameplayScene");
        SceneManager.LoadScene("Sprint3");
        //Back to main menu
    }

    public void CancelPress()
    {
        ShutDownAll();

        InitialiseUI();
    }

    public void BackPress()
    {
        ShutDownAll();
        SceneManager.LoadScene("StartScene");
        // Do something else
    }


    // Update is called once per frame
    void Update()
    {
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




    public void switch2GrabMode()
    {
        dynamicMenu.switch2GrabMode();
    }
    public void switch2TileMode()
    {
        dynamicMenu.switch2TileMode();
    }

    public void switch2TileModeAdd()
    {

        switch2TileMode();
        dynamicMenu.switch2AddMode();
    }

    public void switch2TileModeDelete()
    {
        switch2TileMode();
        dynamicMenu.switch2DeleteMode();
    }

    public void GrabReleasePress()
    {
        movement.GrabRelease();
    }

    public void AddDeletePress()
    {
        movement.AddDelete();
    }
}
