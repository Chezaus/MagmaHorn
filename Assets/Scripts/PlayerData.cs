using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    void Awake()
    {
        if(!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 0);
        }

        if(!PlayerPrefs.HasKey("dashes"))
        {
            PlayerPrefs.SetInt("dashes", 1);
        }

        PlayerPrefs.Save();
    }
    
}
