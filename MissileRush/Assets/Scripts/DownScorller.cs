using UnityEngine;
using System.Collections;

public class DownScorller : MonoBehaviour {

    private PlayerMovement pMovement;

    void Start()
    {
        pMovement = GameObject.FindWithTag(GameTags.player).GetComponent<PlayerMovement>();
        StartCoroutine(Despawn());
    }

	void Update()
    {
        ScrollDown();
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }

    void ScrollDown()
    {
        //ajust speed depending on player
        float scrollSpeed = -pMovement.VerticalSpeed / 30;
        transform.Translate(new Vector2(0, scrollSpeed) * Time.deltaTime);
    }
}
