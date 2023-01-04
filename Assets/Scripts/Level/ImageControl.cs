using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageControl : MonoBehaviour
{
    public GameObject Level1;
    public GameObject Level2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGameFinished.Instance.isLevel1Finished == true)
        {
            Level1.SetActive(true);
        }else
        {
            Level1.SetActive(false);
        }
        if(IsGameFinished.Instance.isLevel2Finished ==true)
        {
            Level2.SetActive(true);
        }else
        {
            Level2.SetActive(false);
        }
    }
}
