using UnityEngine;
public class TouchScreenInput : MonoBehaviour 
{
	private float touchXPosition; 
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			//Checks to see if the player inputs something on the left or right side of the screen.
			touchXPosition = Input.mousePosition.x;
			if (touchXPosition < Screen.width / 2) {
				print ("Mouse is on left side of screen.");
			}

			if (touchXPosition > Screen.width / 2) {
				print ("Mouse is on right side of screen.");
			}
		}
	}
}
