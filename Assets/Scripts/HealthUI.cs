using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Player main;
    public CanvasGroup health1;
    public CanvasGroup health2;
    public CanvasGroup health3;
    public CanvasGroup health4;
    public CanvasGroup health5;
    public CanvasGroup health6;

    void Update()
    {
        switch(main.health){
            case 6:  
                break;
            case 5: health1.alpha = 0;
                break;
            case 4:  health2.alpha = 0; health1.alpha = 0;
                break;
            case 3:  health3.alpha = 0; health2.alpha = 0; health1.alpha = 0;
                break;
            case 2:  health4.alpha = 0; health3.alpha = 0; health2.alpha = 0; health1.alpha = 0;
                break;
            case 1:  health5.alpha = 0; health4.alpha = 0; health3.alpha = 0; health2.alpha = 0; health1.alpha = 0;
                break;
        }
    }

}
