using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoComponent : MonoBehaviour
{
    public GameObject videoClipTest;
    double videoTime;
    double currentTime;
    private bool isVideoStarted;

    private void Start()
    {
        videoTime = videoClipTest.GetComponent<VideoPlayer>().clip.length;
    }
    private void Update()
    {
        if(isVideoStarted)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= videoTime)
            {
                //videoEndEvent
                //Debug.Log("Video ends.");
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Invoke("VideoActive", 2f);
    }

    public void VideoActive()
    {
        //ÍíµãÐ´¸öÖð½¥ÏÔÊ¾
            
        videoClipTest.SetActive(true);
        isVideoStarted=true;
    }
}
