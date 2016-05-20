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
    private Vector3 startPos = new Vector3(0, 10f, 0);

    public delegate void Despawn(int id);
    public static event Despawn OnDespawn;

    private PlayerMovement pMovement;

    //this variable determines the amount of seconds before despawning the background after it has gone offscreen in unity editor
    private float despawnDelay = 1f;

    [SerializeField]
    private bool startChunk;


    void Start()
    {
        pMovement = GameObject.FindWithTag(GameTags.player).GetComponent<PlayerMovement>();

        mainCam = GameObject.FindWithTag(GameTags.mainCam).GetComponent<Camera>();
    }
    void OnEnable()
    {   
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
            //let chunk spawner class know to enable new background
            if (OnDespawn != null)
                OnDespawn(iD);

            StartCoroutine(DelayDespawn());
        }
    }

    IEnumerator DelayDespawn()
    {
        yield return new WaitForSeconds(despawnDelay);
        ObjectPool.instance.PoolObject(gameObject);
    }

    void OnDisable()
    {
        
    }

    void ScrollDown()
    {

        float scrollSpeed = -pMovement.VerticalSpeed / 45;
        transform.Translate(new Vector2(0, scrollSpeed) * Time.deltaTime);
        //ajust speed depending on player
    }
}
