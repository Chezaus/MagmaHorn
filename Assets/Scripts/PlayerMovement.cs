using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	public Dash dash;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetBool("isWalking", Mathf.Abs(horizontalMove) > 0);

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("isJumping", true);
		}	
	}

	public void OnLanding ()
	{
		animator.SetBool("isJumping", false);
	}

	void FixedUpdate ()
	{
		// Move our character
		if(!dash.dashing)
		{
			controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
			jump = false;
		}
		
	}









	
}

