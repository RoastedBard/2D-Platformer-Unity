using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour 
{
	public float movingSpeed;
	public bool movingRight;

	public Transform wallCheck;
	public Transform edgeCheck;
	public float wallCheckRadius;
	public LayerMask whatIsWall;

	private bool hittingWall;

	private bool atEdge;

	void Start () 
	{
	
	}

	void Update () 
	{
		hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
		atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

		if(hittingWall || !atEdge)
			movingRight = !movingRight;

		if(movingRight)
		{
			transform.localScale = new Vector3(-1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else
		{
			transform.localScale = new Vector3(1f, 1f, 1f);
			GetComponent<Rigidbody2D>().velocity = new Vector2(-movingSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}


	}
}
