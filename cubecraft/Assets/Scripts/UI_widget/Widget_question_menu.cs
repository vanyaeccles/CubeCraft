using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    }
    void processConfirmEvent()
    {

    }
}
