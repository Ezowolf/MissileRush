  using UnityEngine;
using System.Collections;
public class FlyOnscreen : MonoBehaviour {
	[SerializeField]
	private Vector2 flyInPosition;
	[SerializeField]
	[Range(.01f,1)]
	private float moveSpeed;

	private Vector2 startPosition;

	private int state = 0;

	[SerializeField]
	[Range(0.01f,2)]
	private float timeInterval;

	[SerializeField]
	private string shootObject; 

	[SerializeField]
	[Range(1,10)]
	private int shootingTimes;

	private GameObject firedObject;

	[SerializeField]
	private AudioClip laser;
	private AudioSource audioSource;

	[SerializeField]
	private float xOffset;

	[SerializeField]
	private float yOffset;

	void OnEnable()
	{
		audioSource = GetComponent<AudioSource>();
        state = 0;
		startPosition = transform.position;
		ActivateShootingProcedure ();
	}

	void FixedUpdate()
	{
		//Executes the actions in the states.
		if(state == 1)
		    FlyTowards (flyInPosition);
		if (state == 2)
		    FlyTowards (startPosition);	
		if (this.transform.position.x == flyInPosition.x&&state==1) 
		{
			StartCoroutine (firingTime());
		}

        //check if shooting enemy is done with his routine
        if(state == 2 && transform.position.x == startPosition.x)
        {
            ObjectPool.instance.PoolObject(gameObject);
        }

	}

	void FlyTowards(Vector2 _flyTarget)
	{
		this.transform.position = Vector2.MoveTowards (this.transform.position, _flyTarget, moveSpeed);
		//Move at the designated speed towards a point.
	}

	IEnumerator firingTime()
	{
		//Starts firing gameobjects using the designated variables
		state = 3;
		for (int i = 0; i < shootingTimes; i++) 
		{
			FireObject ();
			yield return new WaitForSeconds (timeInterval);
		}
		state = 2;
	}

	void FireObject()
	{
		//Fire a object at own position.
		audioSource.PlayOneShot(laser);
		firedObject = ObjectPool.instance.GetObjectForType(shootObject,true);
		firedObject.transform.position = new Vector2 (this.transform.position.x + xOffset, this.transform.position.y + yOffset);
	}

	public void ActivateShootingProcedure()
	{
		//Start moving if idle
		if (state == 0)
			state = 1;
	}
}
