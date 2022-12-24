using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightChange : MonoBehaviour
{
    public float lightValue;
    public PPChange ppChange;
    private bool isLightOn=false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isLightOn)
        {
            ppChange.LightChange();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLightOn = true;
    }

}
