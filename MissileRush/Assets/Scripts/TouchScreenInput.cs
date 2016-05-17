using UnityEngine;

public class TouchScreenInput : MonoBehaviour
{
    private float touchXPosition;
    public bool touchL, touchR;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Checks to see if the player inputs something on the left or right side of the screen.
            touchXPosition = Input.mousePosition.x;
            if (touchXPosition < Screen.width / 2)
            {
                touchL = true;
            }
            else if (touchXPosition > Screen.width / 2)
            {
                touchR = true;
            }
        }
        else
        {
            //if screen isnt touched, set touch pos back to 0
            touchXPosition = 0;
            touchL = false;
            touchR = false;
        }
    }
}