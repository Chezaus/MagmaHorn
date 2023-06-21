using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }
}
