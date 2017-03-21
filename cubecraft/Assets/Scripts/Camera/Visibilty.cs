﻿using System.Collections;
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
        //Resize cubes if a 3x3 problem. 2x2 is default setting
        if (grid.GetSize() == 3)
        {
            GameObject.Find("Player Controlled Cube").transform.position = new Vector3(0, .3f, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        //UpdateVisibilityRaycast();

        //make sure grid is visible, i.e depending on size of problem
        if (grid.GetSize() == 3)
        {
            GameObject.Find("Grid").transform.localScale = new Vector3(.6f, .6f, .6f);
            Debug.LogError("called");
            GameObject.Find("Player Controlled Cube").transform.localScale = new Vector3(.69f, .69f, .69f);
        }

        UpdateVisibilitySlices();
        
    }

    bool isTileOpaque(int i,int j, int k,Vector3i currentTile,Vector3i viewDirection)
    {
        if(viewDirection==new Vector3i(0, 0, 1))
        {
            if (j < currentTile.j || k > currentTile.k)
                return true;
        }
        else if(viewDirection == new Vector3i(1, 0, 0)){
            if (j < currentTile.j || i > currentTile.i)
                return true;
        }
        else if (viewDirection == new Vector3i(0, 0, -1))
        {
            if (j < currentTile.j || k < currentTile.k)
                return true;
        }
        else if (viewDirection == new Vector3i(-1, 0, 0))
        {
            if (j < currentTile.j || i < currentTile.i)
                return true;
        }
            return false;
    }

    void UpdateVisibilitySlices()
    {
        Vector3i viewDirection = movement.forwardVector;
        Vector3i currentTile = movement.GetCurrentTile();
        for (int i = 0; i < grid.GetSize(); i++)
        {
            for (int j = 0; j < grid.GetSize(); j++)
            {
                for (int k = 0; k < grid.GetSize(); k++)
                {
                    if (isTileOpaque(i, j, k, currentTile, viewDirection))
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
