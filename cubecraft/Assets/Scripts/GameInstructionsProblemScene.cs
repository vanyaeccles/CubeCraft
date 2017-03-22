using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstructionsProblemScene : MonoBehaviour {
   
    public GameObject InstructionsHolder;
   
    public void instructions()
    {
        InstructionsHolder.SetActive(!InstructionsHolder.activeInHierarchy);
    }

}
