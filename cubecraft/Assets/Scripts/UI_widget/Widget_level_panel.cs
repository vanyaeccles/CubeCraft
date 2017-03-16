using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Widget_level_panel : MonoBehaviour {
    public GameObject levelArray;
    
    private GameObject array1;
    private GameObject array2;
    private int levelTotal=0;
	// Use this for initialization
	void Start () {
        array1 =     Instantiate(levelArray) as GameObject;
        array1.transform.SetParent(this.transform);
        array2 = Instantiate(levelArray) as GameObject;
        array2.transform.SetParent(this.transform);
        array1.SetActive(false);
        array2.SetActive(false);



        /*
        ***************Attention************************
        * 
        * start :how to use wgt
        *
        */ 
        this.addLevel(1,true,1);
        this.addLevel(1,false,2);
        this.addLevel(1,true,1);

        this.addLevel(1, false, 1);
        this.addLevel(1, true, 2);
        this.addLevel(1,true, 1);
     
        //end:how to use wgt

    }

    // Update is called once per frame
    void Update () {
		
	}



    public void addLevel(int levelID, bool ifPlayed, int star)
    {
        levelTotal++;
        if(levelTotal ==1)
        {
            array1.SetActive(true);
        }else if(levelTotal == 4)
        {
            array2.SetActive(true);
        }

        if (levelTotal <= 3)
        {
             array1.GetComponent<Widget_level_array>().addLevel(levelID, levelTotal,ifPlayed,star);

            //Widget_level_panel xx = array1.GetComponent<Widget_level_panel>();
        }else
        {
            array2.GetComponent<Widget_level_array>().addLevel(levelID, levelTotal, ifPlayed, star);
        }

    }
}
