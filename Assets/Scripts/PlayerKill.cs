using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public Player main;
    public float cooldown;
    public int damage =1;
    bool attack;
    bool lava = false;

    void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            attack = true;
        }

        if(lava && attack)
            {
                main.health -= damage;
                cooldown = 1f;
                attack = false;
            }
    }

    //I used OnTriggerEnter and Exit instead of Stay because they are more consistent
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if(other.tag == "Player")
        {
            lava = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {   
        if(other.tag == "Player")
        {
            lava = false;
        }
    }
}
