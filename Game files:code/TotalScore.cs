using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalScore : MonoBehaviour {

    public static int scoreCount = 0;
    Text score;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCount = ScoreScriptTwo.scoreCount + ScoreScriptOne.scoreCount;
        string myString = scoreCount.ToString();
        score.text = myString;
    }
}
