using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour 
{
	public int enemyHealth;
	public GameObject deathEffect;
	public GameObject hurtEffect;
	public int pointsOnDeath;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(enemyHealth <= 0)
		{
			Instantiate(deathEffect, transform.position, transform.rotation);
			ScoreManager.addPoints(pointsOnDeath);
			Destroy(gameObject);
		}
	}

	public void giveDamage(int damageToGive)
	{
		Instantiate(hurtEffect, transform.position, transform.rotation);
		GetComponent<AudioSource>().Play();
		enemyHealth -= damageToGive;
	}
}
