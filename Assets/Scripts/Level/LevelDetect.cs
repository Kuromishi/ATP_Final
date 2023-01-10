using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelDetect : MonoBehaviour
{
    public character_45du character45Degree;

    public GameObject button_Level1;
    public GameObject button_Level2;

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
    VideoPlayer vp1;
    VideoPlayer vp2;

    private bool setLevel=false;

    private void Start()
    {
        vp1 = videoBomb.GetComponent<VideoPlayer>();
        vp1.url = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Video_Bomb.mp4");
        videoTime1 = vp1.clip.length;
        vp2 = videoLetter.GetComponent<VideoPlayer>();
        vp2.url = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Video1.mp4");
        videoTime2 = vp2.clip.length;
        character45Degree.canMove = true;
    }
    private void Update()
    {
     if(Input.GetKeyDown(KeyCode.E))
        {
            setLevel = true;
        }
    }


    private void FixedUpdate()
    {
        if (setLevel  && button_Level1.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel1Finished == false)
            {
                SceneManager.LoadScene("Level 1");
            }
            else
            {
                PlayVideo1();
                setLevel = false;
            }
        }

        if (setLevel && button_Level2.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel2Finished == false)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (IsGameFinished.Instance.isLevel2Finished)
            {
        
                PlayVideo2();
                setLevel = false;
            }
        }
    }
    public void PlayVideo1()
    {

        videoBomb.SetActive(true);
        isVideoBombStarted = true;
        character45Degree.canMove = false;

        //if (isVideoBombStarted)
        //{
        currentTime1 += Time.fixedDeltaTime;
        //Debug.Log(currentTime1);
        if (currentTime1 >= videoTime1)
        {
            //videoEndEvent
            videoBomb.SetActive(false);
            character45Degree.canMove = true;
            currentTime1 = 0;
            isVideoBombStarted = false;
            
        }
        //}
    }

    public void PlayVideo2()
    {
        videoLetter.SetActive(true);
        isVideoLetterStarted = true;
        character45Degree.canMove = false;

        //if (isVideoBombStarted)
        //{
        currentTime2 += Time.fixedDeltaTime;
        //Debug.Log(currentTime1);
        if (currentTime2 >= videoTime2)
        {
            //videoEndEvent
            videoLetter.SetActive(false);
            character45Degree.canMove = true;
            currentTime2 = 0;
            isVideoLetterStarted = false;

        }
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        button_Level1.SetActive(false);
        button_Level2.SetActive(false);
    }
}
