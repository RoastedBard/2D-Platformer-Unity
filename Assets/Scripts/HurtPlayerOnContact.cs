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

                var player = other.GetComponent<PlayerController>();
                player.knockBackCount = player.knockBackLength;

                if(other.transform.position.x < transform.position.x)
                    player.knockFromRight = true;
                else 
                    player.knockFromRight = false;
			}
		}
	}
}
