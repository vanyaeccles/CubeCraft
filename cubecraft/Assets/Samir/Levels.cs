using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class Levels : MonoBehaviour
{
    Grid grid;
    public bool isInGamePlay;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Start()
    {
        //ProblemHandler.GenerateRandomProblemJSON(2, "Random2.JSON");       
        ProblemHandler.loadProblem("Random2.JSON");
        grid.Resize(ProblemHandler.GetProblemSize());
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(ProblemHandler.GetProblemSize(), grid.GetOffset());
        if (!isInGamePlay)
        {
            ProblemHandler.setProblem(grid);
        }
        //ProblemHandler.GenerateRandomProblemJSON(4, "Random2.JSON");       
    }
}
