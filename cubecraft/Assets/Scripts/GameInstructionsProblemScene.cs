using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructionsProblemScene : MonoBehaviour {
   
    public GameObject InstructionsHolder;
    public GameObject InstructionsHolder2;

    public void instructions()
    {
        InstructionsHolder.SetActive(!InstructionsHolder.activeInHierarchy);
        InstructionsHolder2.SetActive(!InstructionsHolder2.activeInHierarchy);
    }

}
