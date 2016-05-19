using UnityEngine;
using System.Collections;

public class PoolMySelf : MonoBehaviour {

	private int timer = 0;

	void OnEnable()
	{
		timer = 0;
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer++;
		if (timer >= 200) {
			ObjectPool.instance.PoolObject (gameObject);
		}
	}
}
