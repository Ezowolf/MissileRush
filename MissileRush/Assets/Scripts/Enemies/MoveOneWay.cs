using UnityEngine;
using System.Collections;

public class MoveOneWay : MonoBehaviour {

	[SerializeField]
	private Vector2 movementVector;

    private Vector2 startPos = new Vector2(0,6);

    [SerializeField] private bool randomizePosition = false;

    void OnEnable()
    {
        if (randomizePosition)
            transform.position = new Vector2(Random.Range(-1.8f, 1.8f), (Random.Range(10, 17)));
        else
            transform.position = startPos;
    }

	void FixedUpdate () 
	{
		transform.Translate (movementVector*Time.deltaTime, Space.World);
	}
}
