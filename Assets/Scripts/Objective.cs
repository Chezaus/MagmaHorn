using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public Collect main;
    void OnTriggerStay2D(Collider2D other)
    {
        if(main.coins == 3)
        {
            var platform = transform.parent;
            Physics2D.IgnoreCollision(other.GetComponent<PolygonCollider2D>(), platform.GetComponent<Collider2D>());
        }
        
    }

}
