using UnityEngine;
using System.Collections;

public class MoveOneWay : MonoBehaviour {

	[SerializeField]
	private Vector2 movementVector; 
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate (movementVector*Time.deltaTime, Space.World);	
	}
}
