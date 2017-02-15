using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile{

    public Vector3 pos;
    public bool isOccupied;
	
    public Tile(Vector3 Pos, bool IsOccupied)
    {
        pos = Pos;
        isOccupied = IsOccupied;
    }

}
