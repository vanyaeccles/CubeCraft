using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    private Vector2[,] grid;
    public int size = 1;
    public float offset = 1.0f;

    LineRenderer lineRenderer;
    private Vector3[] linePoints;
    
    void Awake()
    {
        grid = new Vector2 [size,size];

        linePoints = new Vector3[size*size*4];

        lineRenderer = GetComponent<LineRenderer>();
    }

	// Use this for initialization
	void Start () {
		for(int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = new Vector2(i * offset, j * offset);
                Vector3 temp = new Vector3(grid[i,j].x, 0 , grid[i,j].y);
              // linePoints[i * size + j] = temp;
               // Debug.Log();
                linePoints[i * size * 4 + j * 4] =  temp - new Vector3(offset*0.5f, 0.0f, offset * 0.5f);
                linePoints[i * size * 4 + j * 4 + 1] = temp - new Vector3(offset * 0.5f, -offset * 0.5f);
                linePoints[i * size * 4 + j * 4 + 2] = temp - new Vector3(-offset * 0.5f, -offset * 0.5f);
                linePoints[i * size * 4 + j * 4 + 3] = temp - new Vector3(-offset * 0.5f, offset * 0.5f);

            }


        }
      //  linePoints[0] = new Vector3(0,0,0);
        //linePoints[1] = new Vector3(1, 0, 0);
        lineRenderer.numPositions = size*size;
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.SetPositions(linePoints);
	}
	

	// Update is called once per frame
	void Update () {
		
	}

    void Render()
    {

    }
}
