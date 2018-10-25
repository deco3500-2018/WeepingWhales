using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingLettersScript : MonoBehaviour
{

    private Vector2 mTopLeft = Vector2.zero;
    private Vector2 mTopMiddle = Vector2.zero;

    private void Awake()
    {
        //Bounding values FULL SCREEN
        mTopLeft = Camera.main.ScreenToWorldPoint(new Vector3(2, Camera.main.pixelHeight, 0));
        mTopMiddle = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth / 2 - 4, Camera.main.pixelHeight,0));

    }
    //The code snippet (How to spawn random prefabs in Unity game. Unity quick tip.) below has been adapted from
	 //https://www.youtube.com/watch?v=ao_BZMORqQw. 



    public GameObject PrefabA;
	private float spawnRate = 1f;

    private float nextSpawn = 0f;

    private int whatToSpawn;

	//random falling letters using switch
    private void Update ()
    {
		if (Time.time > nextSpawn) {
			whatToSpawn = Random.Range (1, 2);

			/*Please ignore the letters that are commented out. For this prototype, as the hangman word is relatively short,
			I don't want to spawn as many letters. However, I want to keep the code because I may need to use them 
			for my last interactive prototype. */
			switch (whatToSpawn) {
			case 1:
                    for (int i = 0; i <= 1; i++)
                    {
                        GameObject letterA = Instantiate(PrefabA, GetPlanePosition(), Quaternion.identity);
                        letterA.name = "A";
                    }
                    
                    break;
			}
			nextSpawn = Time.time + spawnRate;
			//End of code snippet (How to spawn random prefabs in Unity game. Unity quick tip.)
		}
	}

    public Vector3 GetPlanePosition()
    {
        //Random Position on Left side
        float targetX = Random.Range(mTopLeft.x, mTopMiddle.x);
        
        return new Vector3(targetX, mTopLeft.y, 0);
    }
}