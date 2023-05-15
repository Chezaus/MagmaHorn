using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] public Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	[SerializeField] private bool airControl = true;
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private bool dash;
	private int dashes = 1;

	double Wtimer = 0.25;
	double Atimer = 0.25;
	double Stimer = 0.25;
	double Dtimer = 0.25;

	double Wcooldown;
	double Acooldown;
	double Scooldown;
	double Dcooldown;


	bool dashing = false;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
				m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}

		if(m_Grounded)
		{
			dashes = 1;
		}

		Wtimer -= Time.deltaTime;
		Atimer -= Time.deltaTime;
		Stimer -= Time.deltaTime;
		Dtimer -= Time.deltaTime;

		Wcooldown -= Time.deltaTime;
		Acooldown -= Time.deltaTime;
		Scooldown -= Time.deltaTime;
		Dcooldown -= Time.deltaTime;


		

		DashDetect();
	}


	public void Move(float move, bool jump)
	{
		if(!dashing)
		{
			//only control the player if grounded or airControl is turned on
			if (m_Grounded || airControl)
			{

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && m_FacingRight)
				{
					// ... flip the player.
					Flip();
				}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}
		}
	}


	private void DashDetect()
	{

		if(Input.GetKeyDown(KeyCode.W))
		{
			Wcooldown = 0;
			if(Wtimer > 0 && dashes > 0 && Wcooldown <=0)
			{
				m_Rigidbody2D.velocity = new Vector2(0,5);
				dashes -= 1;
				Wtimer = 0;
				Wcooldown = 0.5;
			}
			Wtimer = 0.25;
		}

		if(Input.GetKeyDown(KeyCode.A))
		{
			Acooldown = 0;
			if(Atimer > 0 && dashes > 0 && Acooldown <=0)
			{
				m_Rigidbody2D.velocity = new Vector2(-25,0);
				dashes -= 1;
				Atimer = 0;
				Acooldown = 0.5;
			}
			Atimer = 0.25;
		}

		if(Input.GetKeyDown(KeyCode.S))
		{
			Scooldown = 0;
			if(Stimer > 0 && dashes > 0 && Scooldown <=0)
			{
				m_Rigidbody2D.velocity = new Vector2(0,-25);
				dashes -= 1;
				Stimer = 0;
				Scooldown = 0.5;
			}
			Stimer = 0.25;
		}

		if(Input.GetKeyDown(KeyCode.D))
		{
			Dcooldown = 0;
			if(Dtimer > 0 && dashes > 0 && Dcooldown <=0)
			{
				m_Rigidbody2D.velocity = new Vector2(25,0);
				dashes -= 1;
				Dtimer = 0;
				Dcooldown = 0.5;
			}
			Dtimer = 0.25;
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
