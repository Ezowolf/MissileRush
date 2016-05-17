using UnityEngine;
using System.Collections;

/*
 * This script is responsible for putting the background on the correct position as they spawn.
 * every scrolling background in MissileRush is to have this script attached
 */

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private int iD;
    private Camera mainCam;
    private Vector3 startPos = new Vector3(0, 10, 0);

    public delegate void Despawn(int id);
    public static event Despawn OnDespawn;

    [SerializeField]
    private bool startChunk;

    void OnEnable()
    {
        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        if (startChunk == false)
            transform.position = startPos;
        else
            transform.position = Vector3.zero;
    }

    void Update()
    {
        //check speed at which background needs to move
        ScrollDown();
        //if below screen, go back into objectpool
        CheckPos();
    }

    void CheckPos()
    {
        Vector3 screenPos = mainCam.WorldToScreenPoint(transform.position);
        if (screenPos.y <= -280)
        {
            ObjectPool.instance.PoolObject(gameObject);
        }
    }

    void OnDisable()
    {
        //let chunk spawner class know to enable new background
        if (OnDespawn != null)
            OnDespawn(iD);
    }

    void ScrollDown()
    {
        transform.Translate(new Vector2(0, -2f) * Time.deltaTime);
        //ajust speed depending on player
    }
}
