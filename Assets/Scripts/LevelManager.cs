using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
	public GameObject currentCheckPoint;
	public GameObject deathParticle;
	public GameObject respawnParticle;

	public float respawnDelay;
	public int pointPenaltyOnDeath;

	private PlayerController _player;

	private CameraController _camera;

	public HealthManager healthManager;

	void Start () 
	{
		_player = FindObjectOfType<PlayerController>();
		_camera = FindObjectOfType<CameraController>();
		healthManager = FindObjectOfType<HealthManager>();
	}

	void Update () 
	{
	
	}

	public void respawnPlayer()
	{
		StartCoroutine("respawnPlayer_Crtn");
	}

	public IEnumerator respawnPlayer_Crtn()
	{
		_player.enabled = false;
		_player.GetComponent<Renderer>().enabled = false;
		_camera.isFollowing = false;
		_player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		_player.GetComponent<Rigidbody2D>().gravityScale = 0f;

		Instantiate(deathParticle, _player.transform.position, _player.transform.rotation);

		ScoreManager.addPoints(-pointPenaltyOnDeath);

		yield return new WaitForSeconds(respawnDelay);

		_player.transform.position = currentCheckPoint.transform.position;
		
		Instantiate(respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
		_camera.isFollowing = true;
		_player.enabled = true;
		_player.GetComponent<Renderer>().enabled = true;
		_player.GetComponent<Rigidbody2D>().gravityScale = 5f;

		healthManager.fullHealth();
		healthManager.isDead = false;
	}
}
