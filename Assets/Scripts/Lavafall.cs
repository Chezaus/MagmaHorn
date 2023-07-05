using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavafall : MonoBehaviour
{

    public float topOfFall;
    public float bottomOfFall;
    public float speedOfFall;
    public Rigidbody2D rigidbody2D;

    void Update()
    {
        rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x,-speedOfFall);

        if(transform.position.y <= bottomOfFall)
        {
            transform.position = new Vector2 (transform.position.x,topOfFall);
        }
    }

}
