# ShootemUp
------------
Developers:

1. Mirron Geevarghese Panicker, Cleveland State University, OH, USA
2. Sudharshan Gopi, Cleveland State University, OH, USA

This is a very light Shooting Game developed using Unity and Kinect. Developers - Mirron Geevarghese Panicker, Sudharshan Gopi
A game based on Unity and Kinect where you can kill the enemy characters appearing on the screen at random positions. In the Game, we set the shooting equipment as Player’s Right hand which is a Target image (Game Object: CrossHairGo) in the scene. The Kinect will track the player’s right hand and will link it to CrossHairGo for killing the enemy characters. They can be killed simply by hovering the right hand upon them. The Game displays the information’s such as the count of enemies killed (Score board), Time Left and a Restart Button on the Game Over Panel. We have written a timer function to stop the game after playing for 2 minutes. This is literally the completion of our Game. A restart option is given in the game over panel. The game time can be set to any duration programmatically depends on how long one wants to play the game.

The Game has 3 Scenes in total:
1. This is the starting scene of the Game. ‘SHOOTEMUP’ is the name given to the Game. By clicking GAME ON button, it takes us to the real Game window. For this, we wrote a script named “OpenMainSceneScript”.
  
2. Next is the Game play scene. The actual window where one plays this game. We named this scene as ‘GAMEPLAYSCENE’ and written all the actions needed for the game in a script ‘GamePlayScript’.

3. There is one more scene for the Game over panel. This window will pop up every time when the timer hits zero. There is a Play Again button given in the panel for re-playing.
 

GamePlayScript.cs
-----------------
This script contains main three functions of the Game:
	Time Counter Action: This function will determine the duration of a Game. We wrote this function in such a way to display the time as Minutes and Seconds. For that we declared a variable Game Time and given a value of 100. So as of now, one can play the game single time for 1 minute and 66 seconds.
	Shoot Action: This function will perform the killing of enemies. We set the killing in such a way that when the player’s right hand hovers over the enemy, this action will destroy that avatar and add a point to the score board. Here, we used Raycast Hit for positioning the Gunpoint with the camera. Also, there will be a Gun Shot audio played in the background each time an enemy is killed.
	Restart Action: When the timer hits zero, Game Over window will pop up with a restart button. Restart Action happens by clicking that button for re-playing the Game. This action will reset all the Game parameters such as timer, enemy killed count to default value.
The game Over panel is displayed by enabling alpha value to 1 and it will stop all other actions running behind the game. As default, this value will always be zero.
 


EnemyMakerScript.cs
--------------------
This script will invoke an enemy making action every 3 seconds.
We have loaded five different enemy characters as an array in the unity. We instantiate this game object at any random positions of X and Y axis by calling a ‘Random.Range’ function. We used physics function of gravity (Rigidbody2D) here for making the enemy fall down after pushing them to the top within the frame at a velocity of 650. ‘Addforce’ is the function used to make it realize. 

KinectGesture.cs
-----------------
In the Game, we are using Right hand of the player as the default enemy attacking equipment. We can swipe over our right hand through the enemies to kill them. The script below will check for the Right-Hand Gestures.
 
The other scripts we used are Kinect wrapper, Kinect manager and Kinect Overlayer. Kinect Wrapper script will do the skeleton Tracking and map it to the Kinect manager script. The Kinect overlay script will return the vector 3 value which is the Right-hand position of the player. We are also getting a vector 2 value which defines the Gun point (CrossHairGo) position from the Game play script.

Above code decides the overlapping of vector 2 element over vector 3. RaycastHit is the function which handles this overlapping. If both the vector elements come exactly one over the other, enemy killing action will happen. This will be done by calculating the position of crosshairgo (gun point) and the position of enemy.
