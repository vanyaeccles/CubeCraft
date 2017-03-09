﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour {

    CameraOrbit cam;

	// Use this for initialization
	void Start () {
        cam = GetComponent<CameraOrbit>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            cam.MoveHorizontal(true);
        } else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cam.MoveHorizontal(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            cam.MoveVertical(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            cam.MoveVertical(false);
        }


        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    SceneManager.LoadScene("Sprint3", LoadSceneMode.Single); //Single vs Additive, single will close other scenes, additive will not
        //}

    }
}
