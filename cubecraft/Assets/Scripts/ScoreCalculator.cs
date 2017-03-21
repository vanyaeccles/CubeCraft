using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;


public class ScoreCalculator : MonoBehaviour {

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int StarRater(ProblemHandler.Vec4i score)
    {
        //Grid grid;
        //ProblemHandler.Vec4i score;
        //ProblemHandler.checkSolution(grid,out score);

        float percent = score.k + score.l / (score.i + score.j + score.k + score.l);

        //Only 50% right = 1 star
        //Between 50% and 100% = 2 star
        //All correct gives 3 stars
        if (percent < .5) return 1;
        if (percent < 1) return 2;
        else return 3;

    }

}
