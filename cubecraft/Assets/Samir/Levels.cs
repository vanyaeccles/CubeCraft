using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour {

    // Use this for initialization
    Grid grid;

    public bool isInGamePlay;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }
    void Start () {
        int Level1size = 6;
       // grid.Resize(Level1size);
        if (!isInGamePlay)
        {
            RenderLevel1Problem();
        }
        grid.Resize(Level1size);
        grid = GetComponent<Grid>();
        //grid.SetActive(0, 0, true);
        // grid.SetActive(0, 1, true);
        // grid.SetActive(0, 2, true);

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

    public void RenderLevel1Problem()
    {
       // return;
        int Level1size = 4;
        //grid.Resize(Level1size);

       // grid.SetActive(0, 0, true);
       // grid.SetActive(0, 1, true);
       // grid.SetActive(0, 2, true);
    }

    public void CheckLevel1Solution()
    {
        grid = GetComponent<Grid>();
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

    //public void Level2()
    //{
    //    int Level1size = 5;
    //    size = Level1size;
    //    Resize(size);
    //    grid[0, 1].SetActive(true);
    //    grid[0, 2].SetActive(true);
    //    grid[0, 2].SetActive(true);
    //}
}
