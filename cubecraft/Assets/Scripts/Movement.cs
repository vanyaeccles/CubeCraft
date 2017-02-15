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
   

    // Use this for initialization
    void Start()
    {
        GameObject Plane = GameObject.Find("Plane");
        Grid Grid = Plane.GetComponent<Grid>();
        size = Grid.size;
        grid = Grid.grid;
        //Debug.Log(size); 
        currentTile = new Vector3(.0f, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if (moving)
        {
            pos.y = .5f;
            transform.position = pos;
            moving = false;
        }

    }

    void CheckInput()
    {

        


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            if (grid[(int)currentTile.x, (int)currentTile.z].pos.x <= size-2 && !grid[(int)currentTile.x + 1 , (int)currentTile.z].isOccupied)
            {
                
                currentTile.x += 1;
                pos = grid[(int) currentTile.x, (int) currentTile.z].pos;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].pos.x >= 1.0f && !grid[(int)currentTile.x - 1, (int)currentTile.z].isOccupied)
            {
                
                currentTile.x -= 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].pos;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].pos.z <= size-2 && !grid[(int)currentTile.x, (int)currentTile.z + 1].isOccupied)
            {
                
                currentTile.z += 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].pos;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (grid[(int)currentTile.x, (int)currentTile.z].pos.z >= 1.0f && !grid[(int)currentTile.x, (int)currentTile.z - 1].isOccupied)
            {
                
                currentTile.z -= 1;
                pos = grid[(int)currentTile.x, (int)currentTile.z].pos;
                moving = true;
            }
        }
    }

}
