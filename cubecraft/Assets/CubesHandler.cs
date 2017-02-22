using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesHandler : MonoBehaviour {

    public List<PlacedCube> Cubes;

    public Vector3 v1, v2, v3;

    private int id;

	// Use this for initialization
	void Start () {

        id = 0;

        Cubes = new List<PlacedCube>();


        Vector3 startingPoint = new Vector3(-0.5f, 0, -0.5f);

     

    }
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void addCube(Vector3 pos)
    {

        PlacedCube c = new PlacedCube(pos, false);
        Cubes.Add(c);

    }

    void removeCube(Vector3 pos)
    {
        // find the cube and remove it from the list
    }
}
