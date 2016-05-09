using UnityEngine;
using System.Collections;

/*
 * this script gets the inputs from a PC keyboard
 * and assigns them to sensible booleans
 */

public class KeyboardInput : MonoBehaviour {

    //movement bools
    [HideInInspector]
    public bool up, down, left, right, arrowUp, arrowDown, arrowLeft, arrowRight, shift = false;

	void Update () {
        GetMovementKeys();
	}

    void GetMovementKeys()
    {
        //input for wasd keys
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);

        //input for arrow keys
        arrowUp = Input.GetKey(KeyCode.UpArrow);
        arrowDown = Input.GetKey(KeyCode.DownArrow);
        arrowLeft = Input.GetKey(KeyCode.LeftArrow);
        arrowRight = Input.GetKey(KeyCode.RightArrow);

        shift = Input.GetKey(KeyCode.LeftShift);
    }
}
