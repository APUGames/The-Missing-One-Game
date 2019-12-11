using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
	public float rotationSpeed = 200.0f;

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0, 1, 0), rotationSpeed * Time.deltaTime);
	}
}
