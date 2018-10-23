using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Activate_game: MonoBehaviour
{


    public void PlayGame ()
    {
        //SceneManager.GetActiveScene().buildIndex + 
        SceneManager.LoadScene(1);
        ScoreScriptTwo.scoreCount = 0;
        ScoreScriptOne.scoreCount = 0;
    }
}
