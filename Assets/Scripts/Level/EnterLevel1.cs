using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel1 : MonoBehaviour
{
    public GameObject button_Level1;
    public bool isLevel1Finished;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && button_Level1.activeSelf)
        {
            if (isLevel1Finished == false)
            {
                SceneManager.LoadScene("Level 1");
            }
            else
            {
                //²¥·Åvideo
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<character_45du>()!=null)
        {
            button_Level1.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<character_45du>() != null)
        {
            button_Level1.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button_Level1.SetActive(false);
    }
}
