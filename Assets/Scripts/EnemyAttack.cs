using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Player player;

    public float maxcooldown;
    private float cooldown;
    private bool attack;
    double timer;

    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            attack = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timer = 0.25;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            if(other.tag == "Player" && attack)
            {
                player.health -= 1;
                cooldown = maxcooldown;
                attack = false;
            }
        }
        
    }
}
