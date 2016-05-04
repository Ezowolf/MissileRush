using UnityEngine;
public class Rotater : MonoBehaviour 
{
	[SerializeField]
	private Vector3 rotationVector;
	[Range(0,1000)]
	[SerializeField]
	private float rotationSpeed;
	void Update () 
	{
		transform.Rotate(rotationVector * Time.deltaTime * rotationSpeed);

	}
}
