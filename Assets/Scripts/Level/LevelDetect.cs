using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDetect : MonoBehaviour
{

    [Header("Level 1")]
    public GameObject button_Level1;
    

    [Header("Level 2")]
    public GameObject button_Level2;

    [Header("Video1")]
    public GameObject videoBomb;
    double videoTime;
    double currentTime;
    private bool isVideoBombStarted;


    private void Start()
    {
        videoTime = videoBomb.GetComponent<VideoPlayer>().clip.length;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && button_Level1.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel1Finished == false)
            {
                SceneManager.LoadScene("Level 1");
            }
            else
            {
                //≤•∑≈video
                if (isVideoBombStarted)
                {
                    currentTime += Time.deltaTime;
                    if (currentTime >= videoTime)
                    {
                        //videoEndEvent
                        
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && button_Level2.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel1Finished && IsGameFinished.Instance.isLevel2Finished == false)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (IsGameFinished.Instance.isLevel1Finished && IsGameFinished.Instance.isLevel1Finished)
            {
                //≤•∑≈ ”∆µ
            }
        }
    }

    public void Video1Active()
    {
        videoBomb.SetActive(true);
        isVideoBombStarted = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<EnterLevel1>() != null)
        {
            button_Level1.SetActive(true);
        }

        if (other.GetComponentInParent<EnterLevel2>() != null)
        {
            button_Level2.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<EnterLevel1>() != null)
        {
            button_Level1.SetActive(true);

        }
        if (other.GetComponentInParent<EnterLevel2>() != null)
        {
            button_Level2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button_Level1.SetActive(false);
        button_Level2.SetActive(false);
    }
}
