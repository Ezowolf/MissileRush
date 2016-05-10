using UnityEngine;
using System.Collections;

public class RandomDirection : MonoBehaviour {

	[SerializeField]
	private float movingSpeed = 0.005f;

	private float xVector;

	private float yVector;

	//private Vector2 movementVector;

	private Vector2 randomPosition;


	void Start () 
	{
		randomPosition = new Vector2 (Random.Range (-9999, 9999), Random.Range (-9999, 9999))*999999;
		print (randomPosition);
	}

	void Update () 
	{		
		this.transform.position = Vector2.MoveTowards (this.transform.position, randomPosition, movingSpeed);
	}



}
