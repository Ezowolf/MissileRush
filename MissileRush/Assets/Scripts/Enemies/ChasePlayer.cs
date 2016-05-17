using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {
	[SerializeField]
	private Transform playerTransform;

	[SerializeField]
	private float speed;

	void Start()
	{
		playerTransform = GameObject.FindGameObjectWithTag (GameTags.player).GetComponent<Transform> ();
	}

	void Update () 
	{
		this.transform.position = Vector2.MoveTowards (this.transform.position, (playerTransform.position), speed*Time.deltaTime);
	}
}
