using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] public int lvl;
    public Image button;

    void Start()
    {
        if(PlayerPrefs.GetInt("level") < lvl)
        {
            button.enabled = false;
        }
    }

    public void OnClick()
    {    
        SceneManager.LoadScene("lvl" + lvl);
    }


}
