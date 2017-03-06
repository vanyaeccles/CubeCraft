using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cube
{
    /*Grid.cs
     * The Grid class holds all information relative to the grid which is encapsulated as a 2D array of Tiles.
     * The functions allocate memory and setup the Tiles taking the size parameter into account.
     * Finally the rendering of the grid is handled here as well.
     */
    public class Grid : MonoBehaviour
    {
        //grid information
        private Tile[,,] tiles;
        private int size = 7;
        private float offset = 1.0f;

        //grid rendering
        /*private Vector3[,] gridVertices;
        private LineRenderer lineRenderer;
        private Vector3[] linePoints;
        private int linePointsSize = 0;*/

        //prefabs for setting up the Tiles
        [SerializeField]
        private GameObject cubePrefab;

        void Awake()
        {
            //lineRenderer = GetComponent<LineRenderer>();
            AllocateGrid(size);
        }

        // Use this for initialization
        void Start()
        {
            SetupGrid(size);
        }

        public void Resize(int size)
        {
            DeleteGrid();
            this.size = size;
            AllocateGrid(size);
            SetupGrid(size);
        }

        void AllocateGrid(int size)
        {
            tiles = new Tile[size, size,size];
            //gridVertices = new Vector3[size + 1, size + 1];
            //linePointsSize = 4 + size * 2 + (size % 2 == 0 ? 1 : 0) + 1 + size * 2;
            //linePoints = new Vector3[linePointsSize];
        }

        void DeleteGrid()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        Destroy(tiles[i, j,k].GetGameObject());
                        tiles[i,j,k] = null;
                    }
                }
            }
        }

        void SetupGrid(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        GameObject gameObject = Instantiate(cubePrefab, new Vector3(i * offset, (j*offset) + .5f, k * offset), Quaternion.identity);
                        //gameObject.SetActive(false);
                        tiles[i, j,k] = new Tile(gameObject, false);
                    }
                }
            }

            Vector3 startingPoint = new Vector3(-offset * 0.5f, 0, -offset * 0.5f);
            //for (int i = 0; i < size + 1; i++)
            //{
            //    for (int j = 0; j < size + 1; j++)
            //    {
            //        gridVertices[i, j] = startingPoint + new Vector3(i * offset, 0, j * offset);
            //    }
            //}

            //lineRenderer.widthMultiplier = 0.1f;
            //lineRenderer.numPositions = linePointsSize;

            //int imax = size + 1;
            //int jmax = size + 1;

            //linePoints[0] = gridVertices[0, 0];
            //linePoints[1] = gridVertices[imax - 1, 0];
            //linePoints[2] = gridVertices[imax - 1, jmax - 1];
            //linePoints[3] = gridVertices[0, jmax - 1];

            //int index = 4;

            //for (int i = 0; i < imax - 1; i++)
            //{
            //    int j = i % 2 == 0 ? 0 : jmax - 1;

            //    linePoints[index++] = gridVertices[i, j];
            //    linePoints[index++] = gridVertices[i + 1, j];

            //}

            //if (size % 2 == 0)
            //    linePoints[index++] = gridVertices[imax - 1, 0];
            //linePoints[index++] = gridVertices[0, 0];
            //for (int j = 0; j < jmax - 1; j++)
            //{
            //    int i = j % 2 == 0 ? 0 : imax - 1;
            //    linePoints[index++] = gridVertices[i, j];
            //    linePoints[index++] = gridVertices[i, j + 1];
            //}
            //lineRenderer.SetPositions(linePoints);
        }

        //Getters/Setters
        public void SetActive(int i, int j,int k, bool flag)
        {
            tiles[i, j, k].SetActive(flag);
        }

        public bool GetActive(int i, int j,int k)
        {
            return tiles[i, j, k].GetGameObject().activeInHierarchy;
        }

        public Tile GetTile(int i, int j, int k)
        {
            return tiles[i, j,k];
        }

        public int GetSize()
        {
            return size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }
    }
}
