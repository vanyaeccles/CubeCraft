using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedCube{

    //public int id;

    public Vector3 pos;
    public bool isMoving;


    public PlacedCube(/*int ID,*/ Vector3 Pos, bool IsMoving)
    {
        //id = ID;
        pos = Pos;
        isMoving = IsMoving;
    }

}
