using UnityEngine;
using System.Collections;

public class MoveOneWay : MonoBehaviour {

	[SerializeField]
	private Vector2 movementVector;

    private Vector2 startPos = new Vector2(0,6);

    [SerializeField] private bool randomize = false;

    void OnEnable()
    {
        if (randomize)
            transform.position = new Vector2(Random.Range(-1.5f, 1.5f), 11);
        else
            transform.position = startPos;
    }

	void FixedUpdate () 
	{
		transform.Translate (movementVector*Time.deltaTime, Space.World);
	}
}
