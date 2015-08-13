using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour 
{
	public int damageToGive;
	public GameObject hurtEffect;

	void Start () 
	{
	
	}

	void Update () 
	{
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "Player")
		{
			HealthManager.hurtPlayer(damageToGive);

			if(HealthManager.playerHealth > 0)
			{
				Instantiate(hurtEffect, other.transform.position, other.transform.rotation);
				other.GetComponent<AudioSource>().Play();
			}
		}
	}
}
