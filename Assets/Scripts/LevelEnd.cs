using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] public int level;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(PlayerPrefs.GetInt("level") <= level)
        {
            PlayerPrefs.SetInt("level", level + 1);
            PlayerPrefs.Save();
            
        }
        SceneManager.LoadScene("menu");
    }

    

}
