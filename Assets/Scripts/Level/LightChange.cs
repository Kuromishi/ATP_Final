using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightChange : MonoBehaviour
{
    public float lightOffValue;
    public float lightOnValue;
    public PPChange ppChange;
    private bool isLightOn = true;
    private bool inTrigger = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            if(isLightOn)
            {
                isLightOn = false;
                ppChange.LightOff();
                
            }
            else
            {
                isLightOn = true;
                ppChange.LightOn();
               
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

}
