using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

	/* This script is a duplicate of MoveHippo script that is attached to the Green Hippo gameobject, which 
		modifies the behavior of the green hippo (pretty much the same as the purple hippo). The things that
		are different is the key control, which the key codes are different for the second player. Also, 
		the very last few lines of the code is slightly different. Instead of displaying a 'Purple Hippo Wins'
		image, a 'Green Hippos Wins' image will display if the green hippo wins.*/

[RequireComponent(typeof(Rigidbody))]
public class SecondPlayer : MonoBehaviour
{

	[Tooltip("How fast does this object move?")]
	[SerializeField]
	//speed which the hippo will move
	private float speed = 5.0f;


	public int direction;
	public int playerGreen;

	//initializing moveVelocity for key control of the hippo
	private Vector3 moveVelocity = Vector3.zero;

	void Start(){
		
	}

	/* The overall code (1.Scripting API- Input.GetKey) below made use of the concept of Input.GetKey from:
	 https://docs.unity3d.com/ScriptReference/Input.GetKey.html  

	and the concept of velocity.x = speed from: 
	https://forum.unity3d.com/threads/move-x-velocity-without-bothering-y-velocity.93588/, didn't use
	 rigidbody because no real physics is needed in moving the hippo*/

	private void Update()
	{
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveVelocity.x = speed * 1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            moveVelocity.x = -speed * 1;
        }
        else
        {
            moveVelocity.x = 0;
        }
        this.transform.position += moveVelocity * Time.deltaTime;

        /* The code snippet (Moving the game object on the x-axis a certain amount...) below is adapted from:
         https://stackoverflow.com/questions/32851512/moving-the-gameobject-on-the-x-axis-a-certain-amount-when-left-key-is-pressed-t

        This is used to set the maximum and minimum position which the hippo can reach. (range of movement)
        */

        Vector3 range = transform.position;
        range.x = Mathf.Clamp(range.x, -6, -1);
        transform.position = range;
    }


    //when the hippo eats the letters, detecting collision 
    private void OnTriggerEnter(Collider coll)
    {
        /*this if statement prevents the gameobjects other than the falling letters
          from being destroyed by collision (because the purple hippo may be collide with
          the green hippo, but I don't want them to destroy each other on collision*/
        if (coll.gameObject.tag != "FallingLetters")
            return;

        //referencing the GameManager script here for later use
        GameManager gm = GameManager.instance;

        /*using switch statement to check if falling letter prefabs with the string name 
         "W", "A", "T", "E", and "R" is destroyed. If destroyed, show corresponding letter
          letter tiles */
        string name = coll.gameObject.name;

        /* The code snippet (5. How to spawn random prefabs in Unity game. Unity quick tip.) below has been adapted from
        https://www.youtube.com/watch?v=ao_BZMORqQw. 

        The same concept is used, but code is largely changed because the only thing I have to 
        do here is set the tiles active. */
        switch (name)
        {
            case "A":
                Destroy(coll.gameObject);
                break;
        }
        //End code snippet (5. How to spawn random prefabs in Unity game. Unity quick tip.)

        if (coll.gameObject.name == "A")
        {
            /*The code snippet(7.How to add a score counter into your Unity 2D game? Easy.) below is adapted from: 
            https://www.youtube.com/watch?v=QbqnDbexrCw. 

            Things that are changed are the script name, variable name (scoreValue --> scoreCount), and the value of
            the scores added (10 --> 20). I also added one line of code myself for scores taken off (5 points). */
            ScoreScriptTwo.scoreCount += 1;
        }
    }
}