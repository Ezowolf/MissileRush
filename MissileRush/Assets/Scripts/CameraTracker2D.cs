using UnityEngine;
using System.Collections;

public class CameraTracker2D : MonoBehaviour {

    [SerializeField]
    private GameObject target;

	void Update()
    {
        transform.position = new Vector3(0,target.transform.position.y + 4f, -10);
    }
}