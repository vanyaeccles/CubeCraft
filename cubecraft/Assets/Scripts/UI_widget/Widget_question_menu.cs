using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Widget_question_menu : MonoBehaviour {

    public Button nextQuesButton;
    public Button confirmButton;
    
	// Use this for initialization
	void Start () {
        nextQuesButton.onClick.AddListener(processNextQuesEvent);
        confirmButton.onClick.AddListener(processConfirmEvent);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void processNextQuesEvent()
    {
        Levels.LoadNextLevel();
    }
    void processConfirmEvent()
    {
        GameObject.Find("SceneManager").GetComponent<SceneLoader>().LoadSolutionScene();
        //SceneManager.LoadScene("Sprint3", LoadSceneMode.Single); //Single vs Additive, single will close other scenes, additive will not
    }
}
