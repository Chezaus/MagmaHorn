using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireSpawn : MonoBehaviour
{
    System.Random rnd = new System.Random();
    public float cooldown = 1;
    public GameObject fire;

    void Update()
    {
        Debug.Log(cooldown);
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            Instantiate(fire, new Vector3(rnd.Next(-23,23),63,0), Quaternion.Euler(0,0,rnd.Next(0,360)));
            cooldown = 1;
        }
    }
}
