using UnityEngine;
using System.Collections;

public class DestroyObjectOverTime : MonoBehaviour 
{
	public float lifetime;

	void Start () 
	{
	
	}

	void Update () 
	{
		lifetime -= Time.deltaTime;

		if(lifetime <= 0)
			Destroy(gameObject);
	}
}
