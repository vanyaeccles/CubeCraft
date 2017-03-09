using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class Levels : MonoBehaviour
{

    // Use this for initialization
    Grid grid;
    public static int levelNo = 0;
    int level1size = 2;
    int level2size = 2;
    int levesize;
    public bool isInGamePlay;
    public bool correctSolution;

    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Start()
    {
        correctSolution = false;


        grid.Resize(level1size);
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(level1size, grid.GetOffset());
        if (!isInGamePlay)
        {

            if (UnityEngine.Random.value < 0.5)
            {
                RenderLevel1Problem();
                levelNo = 1;
                Debug.Log(levelNo);
            }
            else
            {
                RenderLevel2Problem();
                levelNo = 2;
            }
        }
    }

    private void Update()
    {
        if (isInGamePlay)
        {
            //if (Input.GetKeyDown(KeyCode.P))
            // {
            // Debug.Log("LevelNo" + levelNo);
            if (levelNo == 1)
            {

                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("checking level 1");
                    CheckLevel1Solution();
                }
            }
            else if (levelNo == 2)
            {

                if (Input.GetKeyDown(KeyCode.P))
                {
                    Debug.Log("checking level 2");
                    CheckLevel2Solution();
                }
            }

        }
    }

    void SetLevel1()
    {
        levesize = level1size;
    }

    public void RenderLevel1Problem()
    {
        grid.Resize(level1size);
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(level1size, grid.GetOffset());
        //position for problem cubes
        grid.SetActive(0, 0, 0, true);
        //grid.SetActive(0, 1, 0, true);
        // grid.SetActive(1, 0, 0, true);
        // grid.SetActive(1, 1, 0, true);
    }


    public void CheckLevel1Solution()
    {
        Debug.Log("Grid size is " + grid.GetSize());
        for (int i = 0; i < grid.GetSize(); i++)
        {
            for (int j = 0; j < grid.GetSize(); j++)
            {
                for (int k = 0; k < grid.GetSize(); k++)
                {
                    if ((i == 0 && (j == 0)) && (k == 0))
                    {
                        if (grid.GetActive(i, j, k))
                        {
                            Debug.Log("Cube shouldn't be over a cube:" + i + "," + j + "," + k);
                            return;
                        }
                    }
                    else
                    {
                        if (!grid.GetActive(i, j, k))
                        {
                            Debug.Log("Cube should be here:" + i + "," + j + "," + k);
                            return;
                        }
                    }
                }
            }
        }
        Debug.Log("Everything right!");
        //For the uihandler to know when to pop the win panel @TODO this is a bit of a hack
        correctSolution = true;
    }



    public void RenderLevel2Problem()
    {
        grid.Resize(level2size);
        GameObject.Find("Main Camera").GetComponent<CameraOrbit>().UpdatePivot(level1size, grid.GetOffset());
        //position for problem cubes
        grid.SetActive(0, 0, 0, true);
        grid.SetActive(0, 0, 1, true);

    }

    public void CheckLevel2Solution()
    {
        Debug.Log("Grid size is " + grid.GetSize());
        for (int i = 0; i < grid.GetSize(); i++)
        {
            for (int j = 0; j < grid.GetSize(); j++)
            {
                for (int k = 0; k < grid.GetSize(); k++)
                {
                    if ((i == 0 && (j == 0)) && (k == 0 || k == 1))
                    {
                        if (grid.GetActive(i, j, k))
                        {
                            Debug.Log("Cube shouldn't be over a cube:" + i + "," + j + "," + k);
                            return;
                        }
                    }
                    else
                    {
                        if (!grid.GetActive(i, j, k))
                        {
                            Debug.Log("Cube should be here:" + i + "," + j + "," + k);
                            return;
                        }
                    }
                }
            }
        }
        Debug.Log("Everthing right");
    }
}
