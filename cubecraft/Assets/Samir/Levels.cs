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
        ProblemHandler.loadProblem("Random1.JSON");
        grid.Resize(ProblemHandler.GetProblemSize());
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(ProblemHandler.GetProblemSize(), grid.GetOffset());
        if (!isInGamePlay)
        {
            ProblemHandler.setProblem(grid);
        }       
    }
}
