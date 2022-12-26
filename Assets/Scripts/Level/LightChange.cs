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
    private GameObject[] AllObj;

    private void Awake()
    {
        GameObject[] floorA = GameObject.FindGameObjectsWithTag("floor");
        
        GameObject[] statusA = GameObject.FindGameObjectsWithTag("status");
        List<GameObject> tempList = new List<GameObject>();
        tempList.AddRange(floorA);
        
        tempList.AddRange(statusA);
        AllObj = tempList.ToArray();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            if(isLightOn)
            {
                isLightOn = false;
                ppChange.LightOff();
                //加灰色
                for(int i=0;i<AllObj .Length ; i++)
                {
                    AllObj[i].GetComponent<MouseFloatAndDrawLine  >().FloorColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnColor(AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor, "gray");
                }
            }
            else
            {
                isLightOn = true;
                ppChange.LightOn();
                //加白色
                for (int i = 0; i < AllObj.Length; i++)
                {
                    AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnColor(AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor, "white");
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;
    }

}
