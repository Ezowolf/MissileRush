using UnityEngine;
using System.Collections;

public class ResetRotation : MonoBehaviour {

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(coll.gameObject.tag == GameTags.side)
        {
            rb.rotation = 0;
        }
    }
}