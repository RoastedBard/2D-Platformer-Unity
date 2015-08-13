using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour 
{
	public static int playerHealth;
	public int maxPlayerHealth;

	public bool isDead;
	Text text;

	private LevelManager _levelManager;

	void Start () 
	{
		text = GetComponent<Text>();

		playerHealth = maxPlayerHealth;

		_levelManager = FindObjectOfType<LevelManager>();

		isDead = false;
	}

	void Update () 
	{
		if(playerHealth <= 0 && !isDead)
		{
			playerHealth = 0;
			_levelManager.respawnPlayer();
			isDead = true;
		}

		text.text = "" + playerHealth;
	}

	public static void hurtPlayer(int damageToGive)
	{
		playerHealth -= damageToGive;
	}

	public void fullHealth()
	{
		playerHealth = maxPlayerHealth;
	}
}
