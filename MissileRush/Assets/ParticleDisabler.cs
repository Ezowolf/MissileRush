using UnityEngine;
using System.Collections;

public class ParticleDisabler : MonoBehaviour {

	void Star()
    {
        StartCoroutine(DisableGameObject());
    }

    IEnumerator DisableGameObject()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
