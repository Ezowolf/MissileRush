using UnityEngine;
using System.Collections;

/*
 * this class will put an object back into the object pool based on its position on the screen
 */

public class PoolObjectOnScreenPos : MonoBehaviour {

    private Camera mainCam;

    void Start()
    {
        mainCam = GameObject.FindWithTag(GameTags.mainCam).GetComponent<Camera>();
    }

    void Update()
    {
        CheckPos();
    }

    void CheckPos()
    {
        //check when enemy has to be put back into objpool
        Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);
        if (screenPos.y <= -180)
        {
            //enemy is offscreen and can be put back in objpool
            ObjectPool.instance.PoolObject(gameObject);
        }
    }

}
