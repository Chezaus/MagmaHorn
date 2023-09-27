using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
        public GameObject player;
        float time = 0;
        void Start()
        {
            if(player == null)
            {
                player = GameObject.Find("Player");
            }
        }
        void OnTriggerEnter2D (Collider2D other) 
        {
        //make the parent platform ignore the jumper
        var platform = transform.parent;
        Physics2D.IgnoreCollision(other.GetComponent<PolygonCollider2D>(), platform.GetComponent<Collider2D>());
    }
     
        void OnTriggerExit2D (Collider2D jumper) 
        {
        //re-enable collision between jumper and parent platform, so we can stand on top again
        var platform = transform.parent;
        Physics2D.IgnoreCollision(jumper.GetComponent<PolygonCollider2D>(), platform.GetComponent<Collider2D>(), false);
        }

        void Update()
        {
            
            time += Time.deltaTime;
            Debug.Log(time);
            if(Input.GetKey(KeyCode.S))
            {
                var platform = transform.parent;
                Physics2D.IgnoreCollision(player.GetComponent<PolygonCollider2D>(), platform.GetComponent<Collider2D>());
                time = 0;
            }
            if(Input.GetKeyUp(KeyCode.S) && time > 0.5f)
            {

                var platform = transform.parent;
                Physics2D.IgnoreCollision(player.GetComponent<PolygonCollider2D>(), platform.GetComponent<Collider2D>(),false);
            }

        }

}
