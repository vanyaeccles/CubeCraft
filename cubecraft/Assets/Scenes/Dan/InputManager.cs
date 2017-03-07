using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.MoveVertical(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.MoveVertical(false);
        }

    }
}
