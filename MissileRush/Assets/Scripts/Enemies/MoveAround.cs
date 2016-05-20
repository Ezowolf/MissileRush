using UnityEngine;
using System.Collections;
public class MoveAround : MonoBehaviour {
	private Vector3 startPosition;
	[SerializeField]
	private float timeInterval = 1;
	[SerializeField]
	private Vector3 flyInPosition;
	private float state = 1;
	[SerializeField]
	private float moveSpeed = 0.1f;

	void Start () 
	{
		startPosition = transform.position;
	}

	IEnumerator changeStateAfterTime(float _whatState)
	{
		yield return new WaitForSeconds (timeInterval);
		state = _whatState;
	}

	void FixedUpdate()
	{
		if(state == 1)
			FlyTowards (flyInPosition);
		if (state == 2)
			FlyTowards (startPosition);
		if (this.transform.position.x == flyInPosition.x&&state==1) 
		{
			StartCoroutine (changeStateAfterTime (2));
		}
		if (this.transform.position.x == startPosition.x&&state==2) 
		{
			StartCoroutine (changeStateAfterTime (1));
		}
	}

	void FlyTowards(Vector2 _flyTarget)
	{
		_flyTarget = new Vector2 (_flyTarget.x, transform.position.y);
		this.transform.position = Vector2.MoveTowards (this.transform.position, _flyTarget, moveSpeed);
		//Move at the designated speed towards a point.
	}
}
