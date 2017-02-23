using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Tile[,] grid;
    private Vector3[,] gridVertices;
    public int size = 1;
    public float offset = 1.0f;

    LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int linePointsSize = 0;

    private GameObject cube; 
    private GameObject solCube;

    private List<PlacedCube> Cubes;

    public GameObject cubePrefab;

    void Awake()
    {
        grid = new Tile [size,size];

        cube = GameObject.Find("Player Controlled Cube");
        solCube = GameObject.Find("Puzzle Cube");

        gridVertices = new Vector3[size + 1, size + 1];
        linePointsSize = 4 + size * 2 + (size % 2 == 0 ? 1 : 0)+1+size*2;
        linePoints = new Vector3[linePointsSize];

        lineRenderer = GetComponent<LineRenderer>();


    }

	// Use this for initialization
	void Start () {
		for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                GameObject gameObject = Instantiate(cubePrefab,new Vector3(i*offset,offset*0.5f,j*offset),Quaternion.identity);
                gameObject.SetActive(false);
                grid[i, j] = new Tile(gameObject, false);
                //grid[i, j] = new Tile(new Vector3(i * offset,0, j * offset), false);
            }
        }

        Vector3 startingPoint = new Vector3(-offset * 0.5f,0, -offset * 0.5f);
        for( int i = 0; i < size + 1; i++)
        {
            for(int j = 0; j < size + 1; j++)
            {
                gridVertices[i,j] = startingPoint + new Vector3(i*offset,0,j*offset);
            }
        }
        
        //linePoints[0] = new Vector3(0,0,0);
        //linePoints[1] = new Vector3(1, 0, 0);
        //lineRenderer.numPositions = size*size;
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.numPositions = linePointsSize;
        //lineRenderer.SetPositions(linePoints);
        Debug.Log(gridVertices);
       

        int imax = size + 1;
        int jmax = size + 1;

        linePoints[0] = gridVertices[0, 0];
        linePoints[1] = gridVertices[imax - 1, 0];
        linePoints[2] = gridVertices[imax - 1, jmax - 1];
        linePoints[3] = gridVertices[0, jmax - 1];
        

        int index = 4;

        for (int i=0; i<imax -1; i++)
        {
            int j = i % 2 ==0 ? 0 : jmax-1;

            linePoints[index++] = gridVertices[i, j];
            linePoints[index++] = gridVertices[i + 1, j];

        }

        if (size % 2 == 0)
            linePoints[index++] = gridVertices[imax-1,0];
        linePoints[index++] = gridVertices[0, 0];
        for(int j = 0; j < jmax-1; j++)
        {
            int i = j % 2 == 0 ? 0 : imax - 1;
            linePoints[index++] = gridVertices[i, j];
            linePoints[index++] = gridVertices[i, j + 1];
        }
        lineRenderer.SetPositions(linePoints);


        //Give it access to the cubes
        GameObject PuzzleCubes = GameObject.Find("Puzzle Cubes");
        
    }
	


	// Update is called once per frame
	void Update () {
        //grid[(int)cube.transform.position.x, (int)cube.transform.position.z].isOccupied = false;
        //grid[(int)solCube.transform.position.x, (int)solCube.transform.position.z].isOccupied = true;

        //Debug functionality//
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    print status of grid[0, 0] on console
        //    Debug.Log("grid[0,0] (downleft corner is isOccupied:" + grid[0, 0].isOccupied.ToString() + " position:" + grid[0, 0].gameObject.transform.pos);
        //}
    }


    void Render()
    {

    }
}
