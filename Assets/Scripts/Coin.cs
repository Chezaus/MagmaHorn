using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Collect main;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Destroy(this.gameObject);
            bool executed = false;
            if(executed == false)
            {
                main.coins++;
                executed = true;
            }
            
        }
    }

}
