using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem{
    [SerializeField]
    public int dimension;

    [SerializeField]
    public tileDataArray2D[] xTiles;

    public void Save(string filename){
        string json_str = JsonUtility.ToJson(this);
        string path = Application.streamingAssetsPath + "/Levels/" + filename;
        Debug.Log("path is " + path);
    }

    public static Problem Load(string filename)
    {
        Debug.Log("SA is " + Application.streamingAssetsPath);
        string path = Application.streamingAssetsPath + "/Levels/" + filename;
        Debug.Log("path iz " + path);
        Problem problem;
        try
        {
            string json_str = System.IO.File.ReadAllText(path);
            Debug.Log("Loaded from " + path);
            problem = JsonUtility.FromJson<Problem>(json_str);
        }
        catch
        {
            problem = null;
        }
        return problem;
    }

    [System.Serializable]
    public struct tileData
    {
        public bool hasCube;
    }

    [System.Serializable]
    public struct tileDataArray
    {
        public tileData[] zTiles;
    }

    [System.Serializable]
    public struct tileDataArray2D
    {
        public tileDataArray[] yTiles;
    }
}
