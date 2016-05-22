using UnityEngine;
using System.Collections;

/*
 * this class makes the clouds move left or right slightly
 */

public class CloudMovement : MonoBehaviour {

    private int direction;
    private Vector2 movement = new Vector2 (2,0);

    void OnEnable()
    {
        direction = Random.Range(0, 2);
        if(direction == 0)
        {
            transform.Translate(movement * Time.deltaTime);
        }
        else
        {
            transform.Translate(-movement * Time.deltaTime);
        }
    }

}
