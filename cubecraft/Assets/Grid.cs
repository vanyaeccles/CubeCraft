using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    private Vector2[,] grid;
    public int size = 4;
    public float offset = 1.0f;

    void Awake()
    {
        grid = new Vector2 [size,size];
    }

	// Use this for initialization
	void Start () {
		for(int i = 0; i < size; i++)
        {
            for(int j = 0; j < size; j++)
            {
                grid[i,j] = new Vector2(i*offset,j*offset);
            }
        }
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
