﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Cube
{
    /*Movement.cs
     * This class implements the movements/actions of the ghost cube in the grid. For each action, there is a corresponding function call. 
     */
    struct Vector3i
    {
        public int i;
        public int j;
        public int k;
        public Vector3i(int i,int j, int k)
        {
            this.i = i;
            this.j = j;
            this.k = k;
        }
    };

    public class Movement : MonoBehaviour
    {
        //grid reference and ghost location in the grid
        private Vector3i currentTile;
        private Grid grid;

        //logic control variables
        private bool holdingCube = false;

        void Awake()
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>(); //@TODO use tag instead of name
        }

        void Start()
        {
            currentTile = new Vector3i(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            //@TODO this code should be removed
            if (holdingCube)
            {
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2GrubMode();
            }
            else if (grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetIsOccupied())
            {
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeDelete();
            }
            else if (!grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetIsOccupied())
            {
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
            }
        }

        private void UpdatePosition()
        {
           transform.position = grid.GetTile(currentTile.i,currentTile.j, currentTile.k).GetGameObject().transform.position;
        }

        public bool MoveRight()
        {
            
            if (currentTile.i < grid.GetSize() - 1 && !(grid.GetTile(currentTile.i + 1, currentTile.j, currentTile.k).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.i += 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }

        public bool MoveLeft()
        {
            if (currentTile.i > 0 && !(grid.GetTile(currentTile.i - 1, currentTile.j, currentTile.k).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.i -= 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }

        public bool MoveForward()
        {
            if (currentTile.k < grid.GetSize() - 1 && !(grid.GetTile(currentTile.i, currentTile.j, currentTile.k + 1).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.k += 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }

        public bool MoveBackward()
        {
            if (currentTile.k > 0 && !(grid.GetTile(currentTile.i, currentTile.j, currentTile.k -1).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.k -= 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }

        public bool MoveUp()
        {
            if (currentTile.j < grid.GetSize() - 1 && !(grid.GetTile(currentTile.i, currentTile.j + 1, currentTile.k).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.j += 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }

        public bool MoveDown()
        {
            if (currentTile.j > 0 && !(grid.GetTile(currentTile.i, currentTile.j - 1, currentTile.k).GetIsOccupied() && holdingCube))
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                currentTile.j -= 1;
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetGameObject().SetActive(true);
                }
                UpdatePosition();
                return true;
            }
            return false;
        }


        public void GrabRelease()
        {
            bool cubeAtPos = grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetIsOccupied();
            if (holdingCube)
            {
                if (!cubeAtPos)
                {
                    Debug.Log("You place the currently grabbed cube.");
                    holdingCube = false;
                    GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileMode();
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(true);
                }

                if (cubeAtPos)
                {
                    Debug.Log("There is already a cube at this position!");
                }
            }
            else
            {
                if (cubeAtPos)
                {
                    Debug.Log("You grab the cube at this position");
                    holdingCube = true;
                    GameObject.Find("UIController").GetComponent<UIHandler>().switch2GrubMode();
                    //remove the placedCube from the cubehandler list, set position to ghostcube position
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetIsOccupied(false);

                }
                else if (!cubeAtPos)
                {
                    Debug.Log("There is nothing to grab!");
                }
            }
        }

        public void AddDelete()
        {
            bool cubeAtPos = grid.GetTile(currentTile.i, currentTile.j, currentTile.k).GetIsOccupied();
            if (holdingCube)
            {
                Debug.Log("You remove the cube that you were holding.");
                grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                holdingCube = false;
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
            }

            else if (!holdingCube)
            {
                if (!cubeAtPos)
                {
                    Debug.Log("You add a new cube at this position.");
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(true);
                    GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeDelete();
                }
                else if (cubeAtPos)
                {
                    Debug.Log("You remove the cube at this position.");

                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                    GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
                }
            }
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}
