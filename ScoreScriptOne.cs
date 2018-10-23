using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScriptOne : MonoBehaviour {

	/*The code snippet(1.How to add a score counter into your Unity 2D game? Easy.) below is adapted from: 
	https://www.youtube.com/watch?v=QbqnDbexrCw. 

	Things that are changed are the variable name (scoreValue --> scoreCount), and the value of the score (0 --> 100) */

	public static int scoreCount = 0;
	Text score;

	// Use this for initialization
	void Start () {
		score = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + scoreCount;
	}
	//End of code snippet (1.How to add a score counter into your Unity 2D game? Easy.)
}
