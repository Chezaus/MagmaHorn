using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    public int lvl = 1;

    void Start()
    {
        
    }

    public void Button()
    {    
        SceneManager.LoadScene("lvl" + lvl);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
        
    }
}
