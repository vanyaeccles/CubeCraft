using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    //public Vector2[,] grid;

    public Vector3 pos = new Vector3(0.0f, .5f, 0.0f);
    private bool moving = false;

    private int size;


    // Use this for initialization
    void Start()
    {
        GameObject Plane = GameObject.Find("Plane");
        Grid Grid = Plane.GetComponent<Grid>();
        size = Grid.size;
        //Debug.Log(size); 
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if (moving)
        {
            transform.position = pos;
            moving = false;
        }

    }

    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //pos.x += 1;
            if (pos.x <= size-2)
            {
                pos += new Vector3(1.0f, 0.0f, 0.0f);
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pos.x >= 1.0f)
            {
                pos.x -= 1;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pos.z <= size-2)
            {
                pos.z += 1;
                moving = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pos.z >= 1.0f)
            {
                pos.z -= 1;
                moving = true;
            }
        }
    }

}
