using UnityEngine;
using System.Collections;

public class ParaTest : MonoBehaviour {

    private float downTime = -4;

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            downTime++;

            Debug.Log(SmoothRotation(downTime));
        }else
        {
            downTime = -4;
            Debug.Log("nothing pressed");
        }

        transform.Translate(new Vector2(SmoothRotation(downTime)/10000, 0));
    }


    float SmoothRotation(float x)
    {
        float y;

        y = -1 * (x * x) + 60;

        return y;
    }
}
