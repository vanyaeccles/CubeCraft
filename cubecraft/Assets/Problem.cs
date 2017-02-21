using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem : MonoBehaviour {
    [SerializeField]
    int dimension;
    [SerializeField]
    tileDataArray[] tiles;
   // [SerializeField]
	// Use this for initialization
	void Start () {
        tiles = new tileDataArray[1];
        tiles[0].row = new tileData[1];
        Save();
	}
    string jsonStr;
	// Update is called once per frame
	void Update () {
		
	}

    void Save(){
        string json = JsonUtility.ToJson(this);
        Debug.Log(json);
    }

    void Load()
    {
        //JsonUtility.FromJson<Problem>(){

        //}
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
}
