using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel2 : MonoBehaviour
{
    public GameObject button_Level2;
    public bool isLevel2Finished;
    public EnterLevel1 level1Object;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && button_Level2.activeSelf)
        {
            if (level1Object.isLevel1Finished && isLevel2Finished==false)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (level1Object.isLevel1Finished && isLevel2Finished)
            {
                //≤•∑≈ ”∆µ
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<character_45du>() != null)
        {
            button_Level2.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<character_45du>() != null)
        {
            button_Level2.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button_Level2.SetActive(false);
    }
}
