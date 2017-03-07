using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class CameraOrbit : MonoBehaviour
{
    //public Transform target;
    public float verticalmov = 90f;
    public float horizontalmov = 90f;
    Vector3 pivot;

    void Start()
    {
        //pivot = new Vector3(1,1,1)* grid.GetSize() * grid.GetOffset() * 0.5f;
       // pivot.x -=0.5f * grid.GetOffset();
        //pivot.z -= 0.5f * grid.GetOffset();
        //center.z += 0.5f * grid.GetOffset();
    }

    public void MoveVertical(bool left)
    {
        transform.RotateAround(pivot, Vector3.up, horizontalmov);
    }
    public void MoveHorizontal(bool up)
    {
        transform.RotateAround(pivot, transform.TransformDirection(Vector3.right), verticalmov);
    }

    public void UpdatePivot(int gridSize, float offset)
    {
        pivot = new Vector3(1, 1, 1) * gridSize * offset * 0.5f;
        pivot.x -= 0.5f * offset;
        pivot.z -= 0.5f * offset;
    }
}
