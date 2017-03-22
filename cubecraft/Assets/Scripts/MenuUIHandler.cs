using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIHandler: MonoBehaviour {



    public Button StartNewGameButton;
	// Use this for initialization
	void Start () {
        Button btn = StartNewGameButton.GetComponent<Button>();
        btn.onClick.AddListener(StartNewGame);
	}

    void StartNewGame()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadLevelsScene();
    }
}
