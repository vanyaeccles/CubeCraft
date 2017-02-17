using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameHandler: MonoBehaviour {
    public Button StartNewGameButton;
	// Use this for initialization
	void Start () {
        Button btn = StartNewGameButton.GetComponent<Button>();
        btn.onClick.AddListener(StartNewGame);
	}

    void StartNewGame()
    {
        Debug.Log("start new game!");
        SceneManager.LoadScene("GameplayScene",LoadSceneMode.Single); //Single vs Additive, single will close other scenes, additive will not
    }
}
