using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKill : MonoBehaviour
{
    public Player main;
    float cooldown = 1;
    bool attack;

    void FixedUpdate()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            attack = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
            if(other.tag == "Player" && attack)
            {
                main.health -= 1;
                cooldown = 1;
                attack = false;
            }
        
    }
}
