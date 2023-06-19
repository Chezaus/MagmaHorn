using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;
    public CharacterController2D controller;
    public PlayerData data;
    public bool dashing;
	private int direction;
    public double timer;
    private int dashes;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        dashes = PlayerPrefs.GetInt("dashes");
    }

    void Update()
    {
        DashDetect();

        timer += Time.deltaTime;

        if(controller.m_Grounded)   {dashes = 1;}
        if(timer >= 0.5) {dashing = false;}
    }

	private void DashDetect()
	{
		if(Input.GetKey(KeyCode.W))	{direction = 0;}
		if(Input.GetKey(KeyCode.A))	{direction = 1;}
		if(Input.GetKey(KeyCode.S))	{direction = 2;}
		if(Input.GetKey(KeyCode.D))	{direction = 3;}

		if(Input.GetKeyDown(KeyCode.Mouse0) && timer >= 0.5 && dashes > 0)
		{
            dashes -= 1;
				switch(direction)
			{
				case 0: m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x/2,15);
                        timer = 0;
                        dashing = true;
					break;
				case 1: m_Rigidbody2D.velocity = new Vector2(-15,m_Rigidbody2D.velocity.y/2);
                        timer = 0;
                        dashing = true;
					break;
				case 2: m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x/2,-15);
                        timer = 0;
                        dashing = true;
					break;
				case 3: m_Rigidbody2D.velocity = new Vector2(15,m_Rigidbody2D.velocity.y/2);
                        timer = 0;
                        dashing = true;
					break;
			}
		}
	}
}
