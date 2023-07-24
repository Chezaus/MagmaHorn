using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool flipped;
    private Rigidbody2D _Rigidbody2D;   
    public float speed = 1;
    public Dash player;

    public void Turn()
    {
        if (!flipped)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            flipped = true;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            flipped = false;
        }
    }

    void Start()
    {
        if(player == null)
        {
            player = GameObject.Find("Player").GetComponent<Dash>();
        }
        _Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float shift = 0;
        if (flipped) { shift = -1; }
        else { shift = 1; }
        transform.position = transform.position + new Vector3(shift * speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerStay2D (Collider2D other)
    {
        if(other.tag == "Player" && player.dashing)
        {
            Destroy(this.gameObject);
        }
    }

}
