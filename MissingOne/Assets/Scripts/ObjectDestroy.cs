﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
	void OnTriggerEnter(Collider Loop)
	{
		if (Loop.tag == "ball")
		{
			Destroy(Loop.gameObject);
		}
	}
}