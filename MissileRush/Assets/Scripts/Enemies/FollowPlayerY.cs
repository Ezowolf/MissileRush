using UnityEngine;
using System.Collections;

public class FollowPlayerY : MonoBehaviour {
	[SerializeField]
	private GameObject target;

	private Vector2 followingVector;

	[SerializeField]
	private float distance;

	private bool stayAtPlayerPosition;

	void Update () 
	{
		followingVector = new Vector2 (this.transform.position.x, target.transform.position.y + distance);	
		this.transform.position = followingVector;
	}
}
