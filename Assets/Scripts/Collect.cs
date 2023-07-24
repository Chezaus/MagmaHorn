using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collect : MonoBehaviour
{

    public int coins;
    public int amount;
    public bool finish;
    public TMP_Text text;

    void Update()
    {
        text.text = (coins).ToString(coins + "/" + amount);
        if(amount >= coins)
        {
            finish = true;
        }
    }


    
 
}
