using UnityEngine;
using System.Collections;

public class OffScreenCheck : MonoBehaviour {

    public Transform target;
    Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 screenPos = camera.WorldToScreenPoint(target.position);
        //Debug.Log("target is " + screenPos.y + " pixels from the top");
        if(screenPos.y <= -280)
        {
            Debug.Log("Remove");
        }
    }
}
