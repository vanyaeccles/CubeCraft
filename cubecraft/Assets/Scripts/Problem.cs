using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem{
    [SerializeField]
    public int dimension;

    [SerializeField]
    public tileDataArray2D[] tiles;

    public void Save(string filename){
        string json_str = JsonUtility.ToJson(this);
        string path = Application.persistentDataPath + "/"+filename;
        System.IO.File.WriteAllText(path, json_str);
        Debug.Log("path is " + path);
    }

    public static Problem Load(string filename)
    {
         string path = Application.persistentDataPath+"/"+filename;
         string json_str=System.IO.File.ReadAllText(path);
         Debug.Log("json string is " + json_str);
         return JsonUtility.FromJson<Problem>(json_str);
    }

    [System.Serializable]
    public struct tileData
    {
        public bool hasCube;
    }

    [System.Serializable]
    public struct tileDataArray
    {
        public tileData[] row;
    }

    [System.Serializable]
    public struct tileDataArray2D
    {
        public tileDataArray[] column;
    }
}
