using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {
	[SerializeField]
	private Transform playerTransform;

	[SerializeField]
	private float speed;

	private Vector2 target;

	void Start()
	{
		playerTransform = GameObject.FindGameObjectWithTag (GameTags.player).GetComponent<Transform> ();
		target = new Vector2 (playerTransform.position.x, playerTransform.position.y * 1.5f);
		//print(target);
	}

	void OnAwake()
	{

	}

	void Update () 
	{
		this.transform.position = Vector2.MoveTowards (this.transform.position, (target), speed*Time.deltaTime);
	}
}
