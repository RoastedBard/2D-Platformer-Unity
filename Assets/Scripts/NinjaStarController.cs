using UnityEngine;
using System.Collections;

public class NinjaStarController : MonoBehaviour 
{
	public float speed;

	public PlayerController player;

	public GameObject enemyDeathEffect;
	public GameObject ninjaStarDestroyedEffect;

	public int pointsForKill;

	public float rotationSpeed;

	public int damageToGive;

	void Start () 
	{
		player = FindObjectOfType<PlayerController>();

		if(player.transform.localScale.x < 0)
		{
			speed = -speed;
			rotationSpeed = -rotationSpeed;
		}

	}

	void Update () 
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

		GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			//Destroy(other.gameObject);
			//Instantiate(enemyDeathEffect, other.transform.position, other.transform.rotation);
			//ScoreManager.addPoints(pointsForKill);
			other.GetComponent<EnemyHealthManager>().giveDamage(damageToGive);
		}
		else
			Instantiate(ninjaStarDestroyedEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}
}
