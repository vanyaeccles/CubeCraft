using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile{

    //public Vector3 pos;
    public GameObject gameObject;
    public bool isOccupied;
	
    public Tile(GameObject gameObject, bool IsOccupied)
    {
        this.gameObject = gameObject;
        isOccupied = IsOccupied;
    }


    public void SetActive(bool flag)
    {
        isOccupied = flag;
        gameObject.SetActive(flag);
    }

    public void SetGameObject(bool flag)
    {
        gameObject.SetActive(flag);
    }


    public void setOccupied(bool flag)
    {
        isOccupied = flag;
    }

}
