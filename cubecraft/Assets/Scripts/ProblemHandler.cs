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
        for (int i = 0; i < problem.tiles.Length; i++)
        {
            for (int j = 0; j < problem.tiles[i].column.Length; j++)
            {
                for (int k = 0; k < problem.tiles[i].column[j].row.Length; k++)
                {
                    grid.SetActive(i, j, k,problem.tiles[i].column[j].row[k].hasCube);
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
        for (int i = 0; i < problem.tiles.Length; i++)
        {
            for (int j = 0; j < problem.tiles[i].column.Length; j++)
            {
                for (int k = 0; k < problem.tiles[i].column[j].row.Length; k++)
                {
                    int ii = (problem.tiles.Length - 1) - i;
                    int kk = (problem.tiles[i].column[j].row.Length - 1) - k;
                    if (grid.GetTile(i, j, k).GetIsOccupied() == problem.tiles[i].column[j].row[k].hasCube)
                    {
                        vote1 = false;
                    }
                    if (grid.GetTile(ii, j, k).GetIsOccupied() == problem.tiles[i].column[j].row[k].hasCube)
                    {
                        vote2 = false;
                    }
                    if (grid.GetTile(i, j, kk).GetIsOccupied() == problem.tiles[i].column[j].row[k].hasCube)
                    {
                        vote3 = false;
                    }
                    if (grid.GetTile(ii, j, kk).GetIsOccupied() == problem.tiles[i].column[j].row[k].hasCube)
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
        problem.tiles = new Problem.tileDataArray2D[dimension];
        for(int i = 0; i < problem.tiles.Length; i++)
        {
            problem.tiles[i].column = new Problem.tileDataArray[dimension];
            for(int j = 0; j < problem.tiles[i].column.Length; j++)
            {
                problem.tiles[i].column[j].row = new Problem.tileData[dimension];
            }
        }
        problem.dimension = dimension;
        for(int i = 0; i < dimension; i++)
        {
            for(int j = 0; j < dimension; j++)
            {
                for(int k = 0; k < dimension; k++)
                {
                    problem.tiles[i].column[j].row[k].hasCube = (Random.Range(-1.0f, 1.0f) > 0.0f);
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
