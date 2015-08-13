using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float movingSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public Transform firePoint;
	public GameObject ninjaStar;
	public float groundCheckRadius;
	public LayerMask whatIsGround;

	public float shotDelay;
	private float shotDelayCounter;

	private bool grounded;
	private bool doubleJump;

	private float movingVelocity;

	private Animator anim;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	void Update () 
	{
		if(grounded)
			doubleJump = false;

		anim.SetBool("grounded", grounded);

		if(Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			jump();
		}
		if(Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
		{
			jump();
			doubleJump = true;
		}

		movingVelocity = 0f;

		if(Input.GetKey(KeyCode.A))
		{
			movingVelocity = -movingSpeed;
		}
		if(Input.GetKey(KeyCode.D))
		{
			movingVelocity = movingSpeed;
		}

		GetComponent<Rigidbody2D>().velocity = new Vector2(movingVelocity, GetComponent<Rigidbody2D>().velocity.y);

		anim.SetFloat("speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(1f, 1f, 1f);
		else if(GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-1f, 1f, 1f);

		if(Input.GetKeyDown(KeyCode.Return))
		{
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}
		if(Input.GetKey(KeyCode.Return))
		{
			shotDelayCounter -= Time.deltaTime;

			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
	}

	void jump()
	{
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
	}
}
