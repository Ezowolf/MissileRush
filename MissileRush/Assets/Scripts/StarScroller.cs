using UnityEngine;
using System.Collections;

public class StarScroller : MonoBehaviour {

    private Vector3 startPos = new Vector3(0, 9.5f, 0);
    private bool starsVisible = false;
    private SpriteRenderer sRender;
    private float alpha;

    void Start()
    {
        BackgroundScroller.OnDespawn += CheckAlphaLevel;
        sRender = GetComponent<SpriteRenderer>();

        //sprite is completely transparent
        sRender.color = new Color(1f, 1f, 1f, 0f);
    }

    void CheckAlphaLevel(int iD)
    {
        //check what background was enabled
        if(iD > 15)
        {
            starsVisible = true;
        }
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -3, 0) * Time.deltaTime);

        if(starsVisible == true)
        {
            alpha += 0.01f;
            //make stars fade in
            sRender.color = new Color(1f, 1f, 1f, alpha);
        }
    }

    void OnBecameInvisible()
    {
        //respawn stars to the top
        transform.position = startPos;
    }

}
