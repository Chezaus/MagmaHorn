using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashbar : MonoBehaviour
{
    public Dash dash;
    float value;
    [SerializeField] Image bar;

    void Update()
    {
        if(dash.timer < 0)  {value = 1;}
        else{value = (float)dash.timer*2;}

        
        bar.fillAmount = value;
    }

}
