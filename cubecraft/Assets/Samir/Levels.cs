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
        if (!ProblemHandler.loadProblem("Level2x2A.JSON"))
        {
            ProblemHandler.GenerateRandomProblemJSON(2, "Level2x2A.JSON");
            ProblemHandler.loadProblem("Level2x2A.JSON");
        }
        grid.Resize(ProblemHandler.GetProblemSize());
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(ProblemHandler.GetProblemSize(), grid.GetOffset());
        if (!isInGamePlay)
        {
            ProblemHandler.setGrid(grid);
        }     
    }
}
