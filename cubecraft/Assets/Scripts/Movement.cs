using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Vector3 currentTile;
    public Tile[,] grid;

    public Vector3 pos = new Vector3(0.0f, .5f, 0.0f);
    private bool moving = false;

    private int size;

    private CubesHandler cubesHandler;
    private GameObject PuzzleCubes;
    private List<PlacedCube> Cubes;
    private bool holdingCube = false;

    public Transform cube;

    // Use this for initialization
    void Start()
    {
        GameObject Plane = GameObject.Find("Plane");
        Grid Grid = Plane.GetComponent<Grid>();
        size = Grid.size;
        grid = Grid.grid;
        //Debug.Log(size); 
        currentTile = new Vector3(.0f, 0.0f, 0.0f);

        GameObject PuzzleCubes = GameObject.Find("Puzzle Cubes");
    }

    // Update is called once per frame
    void Update()
    {

        CheckMovementInput();

        if (moving)
        {
            pos.y = .5f;
            transform.position = pos;
            moving = false;
        }

       
        CheckOtherCommandInput();

    }



    void CheckMovementInput()
    {


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            if (grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position.x <= size - 2 && !(grid[(int)currentTile.x + 1, (int)currentTile.z].isOccupied && holdingCube))
            {
                if(holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetActive(false);
                }

                currentTile.x += 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position;
                moving = true;

                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetGameObject(true);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position.x >= 1.0f && !(grid[(int)currentTile.x - 1, (int)currentTile.z].isOccupied && holdingCube))
            {
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetActive(false);
                }
                currentTile.x -= 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position;
                moving = true;
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetGameObject(true);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position.z <= size - 2 && !(grid[(int)currentTile.x, (int)currentTile.z + 1].isOccupied && holdingCube))
            {
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetActive(false);
                }
                currentTile.z += 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position;
                moving = true;
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetGameObject(true);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position.z >= 1.0f && !(grid[(int)currentTile.x, (int)currentTile.z - 1].isOccupied && holdingCube))
            {
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetActive(false);
                }
                currentTile.z -= 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].gameObject.transform.position;
                moving = true;
                if (holdingCube)
                {
                    grid[(int)currentTile.x, (int)currentTile.z].SetGameObject(true);
                }
            }
        }
        if (!holdingCube)
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].isOccupied)
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeDelete();
            else
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
        }
    }


    public void GrabRelease()
    {
        bool cubeAtPos = grid[(int)pos.x, (int)pos.z].isOccupied;
        if (holdingCube)
        {
            if (!cubeAtPos)
            {
                Debug.Log("You place the currently grabbed cube.");
                holdingCube = false;
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileMode();
                grid[(int)pos.x, (int)pos.z].SetActive(true);
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
                grid[(int)currentTile.x, (int)currentTile.z].setOccupied(false);

            }
            else if (!cubeAtPos)
            {
                Debug.Log("There is nothing to grab!");
            }
        }
    }

    public void AddDelete()
    {
        bool cubeAtPos = grid[(int)pos.x, (int)pos.z].isOccupied;
       // GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileMode();
        if (holdingCube)
        {
            Debug.Log("You remove the cube that you were holding.");
           // GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileMode();
            grid[(int)pos.x, (int)pos.z].SetActive(false);
            holdingCube = false;
            GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
            //if (!cubeAtPos)
            //{
            //    Debug.Log("You place the currently grabbed cube.");
            //    holdingCube = false;
            //    grid[(int)pos.x, (int)pos.z].SetActive(true);
            //}

            //if (cubeAtPos)
            //{
            //    Debug.Log("There is already a cube at this position!");
            //}

        }

        else if (!holdingCube)
        {
            if (!cubeAtPos)
            {
                Debug.Log("You add a new cube at this position.");
                grid[(int)pos.x, (int)pos.z].SetActive(true);
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeDelete();
            }
            else if (cubeAtPos)
            {
                Debug.Log("You remove the cube at this position.");

                grid[(int)pos.x, (int)pos.z].SetActive(false);
                GameObject.Find("UIController").GetComponent<UIHandler>().switch2TileModeAdd();
            }
        }

    }
    void CheckOtherCommandInput()
    {

        bool cubeAtPos = grid[(int)pos.x, (int)pos.z].isOccupied;


            // Grab/Release - Press G
        if (Input.GetKeyDown(KeyCode.G))
        {
            GrabRelease();
            //if(holdingCube)
            //{
            //    Debug.Log("Already have a grabbed cube.");
            //}

            //if(!holdingCube)
            //{
            //    if (cubeAtPos)
            //    {
            //        Debug.Log("You grab the cube at this position");
            //        holdingCube = true;
            //        //remove the placedCube from the cubehandler list, set position to ghostcube position
            //        grid[(int)currentTile.x, (int)currentTile.z].setOccupied(false);

            //    }
            //    else if (!cubeAtPos)
            //    {
            //        Debug.Log("There is nothing to grab!");
            //    }
            //}    
        }



        //Add/Remove - Press N
        if (Input.GetKeyDown(KeyCode.N))
        {
            AddDelete();
            //if(holdingCube)
            //{
            //    if(!cubeAtPos)
            //    {
            //        Debug.Log("You place the currently grabbed cube.");
            //        holdingCube = false;
            //        grid[(int)pos.x, (int)pos.z].SetActive(true);
            //    }

            //    if(cubeAtPos)
            //    {
            //        Debug.Log("There is already a cube at this position!");
            //    }

            //}

            //else if(!holdingCube)
            //{
            //    if (!cubeAtPos)
            //    {
            //        Debug.Log("You add a new cube at this position.");
            //        grid[(int)pos.x, (int)pos.z].SetActive(true);
            //    }
            //    else if (cubeAtPos)
            //    {
            //        Debug.Log("You remove the cube at this position.");

            //        grid[(int)pos.x, (int)pos.z].SetActive(false);
            //    }
            //}
        }
    }




    //Checks to see if there is a cube at the grid position
    bool checkIsPositionFull()
    {
 
        if (grid[(int)currentTile.x, (int)currentTile.z].isOccupied) return true;
        else return false;

     
    }

}
