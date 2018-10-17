using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MoveHippo : MonoBehaviour
{

    [Tooltip("How fast does this object move?")]
    [SerializeField]

	//speed which the hippo will move
    private float speed = 5.0f;

	//using 1 and -1 to indicate which direction the hippo is facing
	public int direction;
	public int playerPurple;


	private Vector3 moveVelocity = Vector3.zero;



	void Start(){
		//initialPos = transform.position;

		//hide the letter tiles initially
		//TileD.SetActive(false);
		//TileO.SetActive(false);
		//TileL.SetActive(false);
		//TileP.SetActive(false);
		//TileH.SetActive(false);
		//TileI.SetActive(false);
		//TileN.SetActive(false);
		//hide the freeze clock image initially
		//clock.SetActive (false);

	}


    /* The overall code (1.Scripting API- Input.GetKey) below made use of the concept of Input.GetKey from:
	 https://docs.unity3d.com/ScriptReference/Input.GetKey.html  

	and the concept of velocity.x = speed from: 
	https://forum.unity3d.com/threads/move-x-velocity-without-bothering-y-velocity.93588/, didn't use
	 rigidbody because no real physics is needed in moving the hippo*/

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            /*player can only bounce the hippo when it is idle, can only bounce once with one key press
			 prevents key press from functioning while bouncing(object is moving)*/
            //if (!moving) {
            //moving = true;
            moveVelocity.x = -speed * 1;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            moveVelocity.x = speed * 1;
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
        range.x = Mathf.Clamp(range.x, 1, 6);
        transform.position = range;
    }
			//}
        //}
		/* The code snippet (2. Y Axis Limit ) below is adapted from: 
		http://answers.unity3d.com/questions/799065/y-axis-limit.html 

		Things changed: created variables on the top for maxYposition and minYposition 
		instead of using integers directly 

		Also, added the condition "!moving", so that the player cannot press other keys when the hippo is moving
		(so that the hippo would no move in diaganol directions)

		This code works to limit the hippo's range of motion, so that the hippo does
		not move out of the scene*/



		//updating object's position
		//this.transform.position += moveVelocity * Time.deltaTime * velocity;
	//}
	//this method is created to function the behavior of bouncing back
	//public void startBouncing()
	//{
		/*two temporary variables are created here, because they are only used in this specific function,
		  if temporary varaibles are not created, it will affect the hippo's performance in other functions*/
		//addVelocityTemp is the force added to push and bounce back the hippo
		//directionTemp is the variable for the object's moving direction
		//float addVelocityTemp = addVelocity;
		//float directionTemp = direction;

		/*when hippo is bouncing back, the direction times -1 makes the hippo go to the opposite direction
		(ie bouncing back, facing direction changed), addvelocity also times -1 to decrease the velocity 
		when bouncing back*/
		/*this code snippet (3. How to change the facing direction...) is adapted from:
		http://answers.unity3d.com/questions/722815/how-to-change-the-facing-direction-of-one-object-w.html

		Only made use of the code: 'direction *= -1' */


		//updating position: a temporary variable of new position after moving is stored here
		/*The code snippet below (4. how would I store this value in a temporary valuable) is adapted from: 
		https://forum.unity.com/threads/how-do-i-store-this-transform-position-value-in-a-temporary-variable.299782/

		Code is not really directly used. Instead, the major concept is used, with if condition
		changed. Transform.position is stored as a temporary value rather in the start(). */



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
		switch (name) {

		//case "N":
			//TileN.SetActive (true);
			//break;
		case "A":
			Destroy(coll.gameObject);
			break;
		//default://this code is to make the hippos not freeze when eating the correct letter prefabs
			//isFrozen = true;
			//when the hippo eats the wrong letter, it freezes, and the freeze clock image displays
			//clock.SetActive (true);
			//break;
		}
		//End code snippet (5. How to spawn random prefabs in Unity game. Unity quick tip.)



       //this checks if the player wins the game,this is used with the GameManager script
	   /*After all the tiles are active, call PurpleWon function in GameManager script, 
	    so that the PurpleWin image is displayed */
		/*The code snippet (6.if gameobject is active) below is adapted from: http://answers.unity3d.com/questions/44137/if-gameobject-is-active.html
		(the last comment).

		Things that are changed: input my own GameObject name, and the result of the condition is also
		changed. */
		//if (TileD.activeSelf && TileO.activeSelf && TileL.activeSelf && TileP.activeSelf && TileH.activeSelf && TileI.activeSelf && TileN.activeSelf)
        //{
        //    gm.PurpleWon(playerPurple);
        //}
		//End of code snippet (6.if gameobject is active)

		//destroys gameobject (falling letters) on collision
        //Destroy(coll.gameObject);


		if (coll.gameObject.name == "A") {
			/*The code snippet(7.How to add a score counter into your Unity 2D game? Easy.) below is adapted from: 
			https://www.youtube.com/watch?v=QbqnDbexrCw. 

			Things that are changed are the script name, variable name (scoreValue --> scoreCount), and the value of
			the scores added (10 --> 20). I also added one line of code myself for scores taken off (5 points). */
			ScoreScriptOne.scoreCount += 1;
		} //if the hippo eats the bonus, the score increases by 30 points
		//else if(coll.gameObject.name == "Bonus"){
		//	ScoreScriptOne.scoreCount += 30;
		//}
		//else {
		//	ScoreScriptOne.scoreCount -= 5;
			//End of code snippet(7.How to add a score counter into your Unity 2D game? Easy.)
		//}
    }
}