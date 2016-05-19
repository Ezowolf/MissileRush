using UnityEngine;
using System.Collections;

public class movedown : MonoBehaviour {

    void OnEnable()
    {
        float random = Random.Range(-2.5f, 2.5f);
        transform.position = new Vector3(random, 10, 0);
    }

	void Update()
    {
        transform.Translate(new Vector3(0, -5, 0)* Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        ObjectPool.instance.PoolObject(gameObject);
    }
}
