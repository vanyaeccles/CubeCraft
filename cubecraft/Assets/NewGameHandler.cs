using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameHandler : MonoBehaviour {
    public Button StartNewGameButton;
	// Use this for initialization
	void Start () {
        Button btn = StartNewGameButton.GetComponent<Button>();
        btn.onClick.AddListener(StartNewGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartNewGame()
    {
        Debug.Log("start new game!");

    }
}
