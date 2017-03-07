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

        public Vector3i(Vector3i v)
        {
            this.i = v.i;
            this.j = v.j;
            this.k = v.k;
        }

        public static Vector3i operator *(Vector3i v, float f)
        {
            return new Vector3i(v.i*(int)f , v.j *(int) f, v.k *(int) f);
        }

        public static Vector3i operator +(Vector3i v, Vector3i v2)
        {
            return new Vector3i(v.i + v2.i, v.j + v2.j, v.k + v2.k);
        }
    };



    public class Movement : MonoBehaviour
    {
        //grid reference and ghost location in the grid
        private Vector3i currentTile;
        private Grid grid;
        private Vector3i forwardVector;
        private Vector3i backwardVector;
        private Vector3i rightVector;
        private Vector3i leftVector;

        //logic control variables
        private bool holdingCube = false;

        void Awake()
        {
            grid = GameObject.Find("Grid").GetComponent<Grid>(); //@TODO use tag instead of name
        }

        void Start()
        {
            currentTile = new Vector3i(0, 0, 0);
            checkDirection();
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

            //if (currentTile.i < grid.GetSize() - 1 && !(grid.GetTile(currentTile.i + 1, currentTile.j, currentTile.k).GetIsOccupied() && holdingCube))
            if (checkIfMoveRight())
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                //currentTile.i += 1;
                currentTile += rightVector;
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
            //if (currentTile.i > 0 && !(grid.GetTile(currentTile.i - 1, currentTile.j, currentTile.k).GetIsOccupied() && holdingCube))
            if(checkIfMoveLeft())
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                //currentTile.i -= 1;
                currentTile += leftVector;
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
            //if (currentTile.k < grid.GetSize() - 1 && !(grid.GetTile(currentTile.i, currentTile.j, currentTile.k + 1).GetIsOccupied() && holdingCube))
            if (checkIfMoveForward())
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                //currentTile.k += 1;
                currentTile += forwardVector;
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
            //if (currentTile.k > 0 && !(grid.GetTile(currentTile.i, currentTile.j, currentTile.k -1).GetIsOccupied() && holdingCube))
            if(checkIfMoveBackwards())
            {
                if (holdingCube)
                {
                    grid.GetTile(currentTile.i, currentTile.j, currentTile.k).SetActive(false);
                }
                //currentTile.k -= 1;
                currentTile += backwardVector;
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


        public void checkDirection()
        {
            GameObject camera = GameObject.Find("Main Camera");
            Vector3 direction = camera.transform.forward;

            if(Mathf.Abs(direction.x) < Mathf.Abs(direction.z))
            {
                if (direction.z < 0)
                {
                    forwardVector = new Vector3i(0, 0, 1) * Mathf.Sign(direction.z);
                    leftVector = new Vector3i(1, 0, 0) * Mathf.Sign(direction.x);
                    rightVector = new Vector3i(leftVector) * -1.0f;
                }
                else
                {
                    forwardVector = new Vector3i(0, 0, 1) * Mathf.Sign(direction.z);
                    rightVector = new Vector3i(1, 0, 0) * Mathf.Sign(direction.x);
                    leftVector = new Vector3i(rightVector) * -1.0f;
                }
            }
            else
            {
                if (direction.x > 0)
                {
                    forwardVector = new Vector3i(1, 0, 0) * Mathf.Sign(direction.x);
                    rightVector = new Vector3i(0, 0, 1) * Mathf.Sign(direction.z);
                    leftVector = new Vector3i(rightVector) * -1.0f;
                }
                else
                {
                    forwardVector = new Vector3i(1, 0, 0) * Mathf.Sign(direction.x);
                    leftVector = new Vector3i(0, 0, 1) * Mathf.Sign(direction.z);
                    rightVector = new Vector3i(leftVector) * -1.0f;
                }
            }
            backwardVector = new Vector3i(forwardVector) * -1.0f;
            

            Debug.Log("" + forwardVector.i + "  " + forwardVector.j + "   " + forwardVector.k);
            Debug.Log("" + rightVector.i + "  " + rightVector.j + "   " + rightVector.k);

        }



        public bool checkIfMoveRight()
        {
            Vector3i checker = new Vector3i(0, 0, 0);
            checker = rightVector + currentTile;
            if (checker.i < 0 || checker.i > 2) return false;
            if (checker.j < 0 || checker.j > 2) return false;
            if (checker.k < 0 || checker.k > 2) return false;
            if (grid.GetTile(checker.i, checker.j, checker.k).GetIsOccupied() && holdingCube) return false;
            return true;
        }


        public bool checkIfMoveLeft()
        {
            Vector3i checker = new Vector3i(0, 0, 0);
            checker = leftVector + currentTile;
            if (checker.i < 0 || checker.i > 2) return false;
            if (checker.j < 0 || checker.j > 2) return false;
            if (checker.k < 0 || checker.k > 2) return false;
            if (grid.GetTile(checker.i, checker.j, checker.k).GetIsOccupied() && holdingCube) return false;
            return true;
        }


        public bool checkIfMoveForward()
        {
            Vector3i checker = new Vector3i(0, 0, 0);
            checker = forwardVector + currentTile;
            if (checker.i < 0 || checker.i > 2) return false;
            if (checker.j < 0 || checker.j > 2) return false;
            if (checker.k < 0 || checker.k > 2) return false;
            if (grid.GetTile(checker.i, checker.j, checker.k).GetIsOccupied() && holdingCube) return false;
            return true;
        }


        public bool checkIfMoveBackwards()
        {
            Vector3i checker = new Vector3i(0, 0, 0);
            checker = backwardVector + currentTile;
            if (checker.i < 0 || checker.i > 2) return false;
            if (checker.j < 0 || checker.j > 2) return false;
            if (checker.k < 0 || checker.k > 2) return false;
            if (grid.GetTile(checker.i, checker.j, checker.k).GetIsOccupied() && holdingCube) return false;
            return true;
        }


    }

}
