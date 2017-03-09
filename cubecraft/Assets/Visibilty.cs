using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class Visibilty : MonoBehaviour {

    Grid grid;
    Movement movement;
    Transform ghostCubeTransform;
    public Material transparentMat;
    public Material occupiedMat;
    public Material gridMat;

    // Use this for initialization
    void Awake()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        ghostCubeTransform = GameObject.Find("Player Controlled Cube").transform;
        movement = GameObject.Find("Player Controlled Cube").GetComponent<Movement>();
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //UpdateVisibilityRaycast();
        UpdateVisibilitySlices();
        
    }

    void UpdateVisibilitySlices()
    {
        Vector3i viewDirection = movement.forwardVector;
        Debug.Log("" + viewDirection.i + "     " + viewDirection.j + "    " + viewDirection.k);
        Vector3i currentTile = movement.GetCurrentTile();
        //Debug.Log("" + currentTile.i + "     " + currentTile.j + "    " + currentTile.k);
        if (viewDirection == new Vector3i(0, 0, 1))
        {
            for (int i = 0; i < grid.GetSize(); i++)
            {
                for (int j = 0; j < grid.GetSize(); j++)
                {
                    for (int k = 0; k < grid.GetSize(); k++)
                    {
                        if (j < currentTile.j || k > currentTile.k)
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                            }
                            else
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                            }
                        }
                        else
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat;
                            }

                        }
                    }
                }
            }
        }

        else if (viewDirection == new Vector3i(1, 0, 0))
        {
            for (int i = 0; i < grid.GetSize(); i++)
            {
                for (int j = 0; j < grid.GetSize(); j++)
                {
                    for (int k = 0; k < grid.GetSize(); k++)
                    {
                        if (j < currentTile.j || i > currentTile.i)
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                            }
                            else
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                            }
                        }
                        else
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat;
                            }

                        }
                    }
                }
            }
        }

        else if (viewDirection == new Vector3i(0, 0, -1))
        {
            for (int i = 0; i < grid.GetSize(); i++)
            {
                for (int j = 0; j < grid.GetSize(); j++)
                {
                    for (int k = 0; k < grid.GetSize(); k++)
                    {
                        if (j < currentTile.j || k < currentTile.k)
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                            }
                            else
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                            }
                        }
                        else
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat;
                            }

                        }
                    }
                }
            }
        }

        else if (viewDirection == new Vector3i(-1, 0, 0))
        {
            for (int i = 0; i < grid.GetSize(); i++)
            {
                for (int j = 0; j < grid.GetSize(); j++)
                {
                    for (int k = 0; k < grid.GetSize(); k++)
                    {
                        if (j < currentTile.j || i < currentTile.i)
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                            }
                            else
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                            }
                        }
                        else
                        {
                            if (grid.GetTile(i, j, k).GetIsOccupied())
                            {
                                grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = transparentMat;
                            }

                        }
                    }
                }
            }
        }


    }

    void UpdateVisibilityRaycast()
    {
        //set cubes back to normal opacity
        for(int i = 0; i < grid.GetSize(); i++)
        {
            for(int j = 0; j < grid.GetSize(); j++)
            {
                for(int k = 0; k < grid.GetSize(); k++)
                {
                    if (grid.GetTile(i, j, k).GetIsOccupied())
                    {
                        grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = occupiedMat;
                    }
                    else
                    {
                        grid.GetTile(i, j, k).GetGameObject().GetComponent<Renderer>().material = gridMat;
                    }
                }
            }
        }
        //make the occluding ones transparent
        RaycastHit[] hits;
        hits=Physics.RaycastAll(transform.position, ghostCubeTransform.position - transform.position);
       for(int i = 0; i < hits.Length; i++)
        {
            Vector3i indices = hits[i].transform.GetComponent<TileInfo>().GetTileIndex();
            if (grid.GetTile(indices.i, indices.j, indices.k).GetIsOccupied())
            {
                hits[i].transform.GetComponent<Renderer>().material = transparentMat;
            }
        }
    }
}
