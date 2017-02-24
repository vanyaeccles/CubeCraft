using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    // Use this for initialization
    Grid grid;
    int level1size = 4;
    int level2size = 5;
    int levesize;
    public bool isInGamePlay;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Start () {

        grid.Resize(level1size);
        if (!isInGamePlay)
        {
            RenderLevel1Problem();
        }
    }

    private void Update()
    {
        if (isInGamePlay) {
            if (Input.GetKeyDown(KeyCode.P))
            {
                CheckLevel1Solution();
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

        grid.SetActive(0, 0, true);
        grid.SetActive(0, 1, true);
        grid.SetActive(0, 2, true);
    }

    public void RenderLevel2Problem()
    {
        //le
        grid.Resize(level1size);

        grid.SetActive(0, 0, true);
        grid.SetActive(0, 1, true);
        grid.SetActive(0, 2, true);
    }

    public void CheckLevel1Solution()
    {
        Debug.Log("Grid size is " + grid.size);
        for (int i = 0; i < grid.size; i++)
        {
            for (int j = 0; j < grid.size; j++)
            {
                if (i == 0 && (j == 0 || j == 1 || j == 2))
                {
                    if (grid.GetActive(i, j))
                    {
                        Debug.Log("Cube shouldn't be over a cube:" + i + "," + j);
                        return;
                    }
                }
                else
                {
                    if (!grid.GetActive(i, j))
                    {
                        Debug.Log("Cube should be here:" + i + "," + j);
                        return;
                    }
                }
            }
        }
        Debug.Log("Everthing right");
    }

    public void CheckLevel2Solution()
    {
        Debug.Log("Grid size is " + grid.size);
        for (int i = 0; i < grid.size; i++)
        {
            for (int j = 0; j < grid.size; j++)
            {
                if (i == 0 && (j == 0 || j == 1 || j == 2))
                {
                    if (grid.GetActive(i, j))
                    {
                        Debug.Log("Cube shouldn't be over a cube:" + i + "," + j);
                        return;
                    }
                }
                else
                {
                    if (!grid.GetActive(i, j))
                    {
                        Debug.Log("Cube should be here:" + i + "," + j);
                        return;
                    }
                }
            }
        }
        Debug.Log("Everthing right");
    }
}
