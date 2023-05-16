using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Player main;

    private void OnTriggerEnter(Collider2D other)
    {
        if(other.tag == "Player")
        {
            main.health -= 1;
        }
    }
}
