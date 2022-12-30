using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDetect : MonoBehaviour
{
    public character_45du character45Degree;

    public GameObject button_Level1;
    public GameObject button_Level2;
    public GameObject button_System;

    [Header("Video1")]
    public GameObject videoBomb;
    double videoTime1;
    double currentTime1;
    private bool isVideoBombStarted;

    [Header("Video2")]
    public GameObject videoLetter;
    double videoTime2;
    double currentTime2;
    private bool isVideoLetterStarted;

    private void Start()
    {
        videoTime1 = videoBomb.GetComponent<VideoPlayer>().clip.length;
        videoTime2 = videoLetter.GetComponent<VideoPlayer>().clip.length;
        character45Degree.canMove = true;
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
                //play video
                Video1Active();
                
                if (isVideoBombStarted)
                {
                    currentTime1 += Time.deltaTime;
                    if (currentTime1 >= videoTime1)
                    {
                        //videoEndEvent
                        videoBomb.SetActive(false);
                        character45Degree.canMove = true;
                        currentTime1 = 0;
                        isVideoBombStarted = false;
                    }
                }


            }
        }

        if (Input.GetKeyDown(KeyCode.E) && button_Level2.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel2Finished == false)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (IsGameFinished.Instance.isLevel2Finished)
            {
                Video2Actice();
                
                if (isVideoLetterStarted)
                {
                    currentTime2 += Time.deltaTime;
                    if (currentTime2 >= videoTime2)
                    {
                        //videoEndEvent
                        videoLetter.SetActive(false);
                        character45Degree.canMove = true;
                        currentTime2 = 0;
                        isVideoLetterStarted = false;
                    }
                }
            }
        }
    }

    public void Video1Active()
    {
        videoBomb.SetActive(true);
        isVideoBombStarted = true;
        character45Degree.canMove = false;
    }

    public void Video2Actice()
    {
        videoLetter.SetActive(true);
        isVideoLetterStarted = true;
        character45Degree.canMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<EnterLevel1>() != null)
        {
            button_Level1.SetActive(true);
        }

        if (other.GetComponentInParent<EnterLevel2>() != null && IsGameFinished.Instance.isLevel1Finished)
        {
            button_Level2.SetActive(true);
        }

        if (other.GetComponentInParent<SystemEnter>() != null && IsGameFinished.Instance.isLevel2Finished)
        {
            button_System.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<EnterLevel1>() != null)
        {
            button_Level1.SetActive(true);

        }
        if (other.GetComponentInParent<EnterLevel2>() != null && IsGameFinished.Instance.isLevel1Finished)
        {
            button_Level2.SetActive(true);
        }
        if (other.GetComponentInParent<SystemEnter>() != null && IsGameFinished.Instance.isLevel2Finished)
        {
            button_System.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button_Level1.SetActive(false);
        button_Level2.SetActive(false);
        button_System.SetActive(false);
    }
}
