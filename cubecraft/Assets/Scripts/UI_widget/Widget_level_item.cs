﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Widget_level_item : MonoBehaviour {


    public int LevelID;
    public GameObject star;
    public Button lvlbutton;
    public Image lvlImage;
    public Sprite[] images;

    public Sprite[] star_imgs;
    public int levelIndex;//only for UI
	// Use this for initialization
	void Start () {
        lvlbutton.onClick.AddListener(processSelectLevelEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void init(int levelID, int levelIndex, bool ifPlayed,int starNum)
    {
       
       lvlImage.sprite = images[levelIndex-1];
         star.GetComponent<Image>().sprite = star_imgs[starNum - 1];
        Debug.Log(starNum);


        if (ifPlayed)
        {
            star.SetActive(true);
        }else
        {
            star.SetActive(false);
        }
    }



    void processSelectLevelEvent()
    {

    }
}
