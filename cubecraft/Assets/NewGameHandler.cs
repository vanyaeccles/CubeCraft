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
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadProblemScene();
        //SceneManager.LoadScene("Samir/ProblemScene", LoadSceneMode.Single); //Single vs Additive, single will close other scenes, additive will not
    }
}
