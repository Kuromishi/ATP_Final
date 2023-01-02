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


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && button_Level1.activeSelf)
        {
            if (IsGameFinished.Instance.isLevel1Finished == false)
            {
                SceneManager.LoadScene("Level 1");
            }
            else
            {
                StartCoroutine(PlayVideo1());
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
                StartCoroutine(PlayVideo2());
               
            }
        }
    }
    IEnumerator PlayVideo1()
    {
        yield return new WaitForSeconds(1);
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
            yield return null;
        }
        //}
    }

    IEnumerator PlayVideo2()
    {
        yield return new WaitForSeconds(1);
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

            yield return null;
        }
        //}
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
