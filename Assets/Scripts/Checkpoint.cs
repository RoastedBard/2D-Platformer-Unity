﻿using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour 
{
	private LevelManager levelManager;
	
	void Start () 
	{
		levelManager = FindObjectOfType<LevelManager>();
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			levelManager.currentCheckPoint = gameObject;
		}
	}	
}
