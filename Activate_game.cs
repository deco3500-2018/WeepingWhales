using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Activate_game: MonoBehaviour
{


    public void PlayGame ()
    {
        
        SceneManager.LoadScene(1);
    }
}
