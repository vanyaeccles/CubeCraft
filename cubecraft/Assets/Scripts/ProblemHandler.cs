using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class ProblemHandler
{
    static Problem problem;
    public static bool loadProblem(string path)
    {
        problem = Problem.Load(path);
        if (problem == null) return false;
        return true;
    }

   public static void setProblem(Grid grid)
    {
        for (int i = 0; i < problem.xTiles.Length; i++)
        {
            for (int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                for (int k = 0; k < problem.xTiles[i].yTiles[j].zTiles.Length; k++)
                {
                    grid.SetActive(i, j, k,problem.xTiles[i].yTiles[j].zTiles[k].hasCube);
                }
            }
        }
    }

   public static bool checkSolution(Grid grid)
    {
        bool vote1 = true;
        bool vote2 = true;
        bool vote3 = true;
        bool vote4 = true;
        for (int i = 0; i < problem.xTiles.Length; i++)
        {
            for (int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                for (int k = 0; k < problem.xTiles[i].yTiles[j].zTiles.Length; k++)
                {
                    int ii = (problem.xTiles.Length - 1) - i;
                    int kk = (problem.xTiles[i].yTiles[j].zTiles.Length - 1) - k;
                    if (grid.GetTile(i, j, k).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote1 = false;
                    }
                    if (grid.GetTile(ii, j, k).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote2 = false;
                    }
                    if (grid.GetTile(i, j, kk).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote3 = false;
                    }
                    if (grid.GetTile(ii, j, kk).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote4 = false;
                    }
                }
            }
        }
        return (vote1 || vote2 || vote3 || vote4);
    }

    public static void GenerateRandomProblemJSON(int dimension,string path)
    {
        Problem problem = new Problem();
        problem.xTiles = new Problem.tileDataArray2D[dimension];
        for(int i = 0; i < problem.xTiles.Length; i++)
        {
            problem.xTiles[i].yTiles = new Problem.tileDataArray[dimension];
            for(int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                problem.xTiles[i].yTiles[j].zTiles = new Problem.tileData[dimension];
            }
        }
        problem.dimension = dimension;
        for(int i = 0; i < dimension; i++)
        {
            for(int j = 0; j < dimension; j++)
            {
                for(int k = 0; k < dimension; k++)
                {
                    problem.xTiles[i].yTiles[j].zTiles[k].hasCube = (Random.Range(-1.0f, 1.0f) > 0.0f);
                }
            }
        }
        problem.Save(path);
    } 

    public static int GetProblemSize()
    {
        return problem.dimension;
    }
}
