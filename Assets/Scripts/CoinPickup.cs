using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour 
{
	public int pointsToAdd;
	public AudioSource coinSound;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<PlayerController>() == null)
			return;

		ScoreManager.addPoints(pointsToAdd);

		coinSound.Play();

		Destroy (gameObject);
	}
}
