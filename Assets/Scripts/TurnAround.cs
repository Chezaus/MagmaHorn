using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public bool OnExit;
    public Enemy main;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (OnExit & other.tag == "Ground")
        {
            main.Turn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!OnExit)
        {
            if(other.tag == "Ground"| other.tag == "Enemy")
            {
                main.Turn();
            }
        }
    }
}
