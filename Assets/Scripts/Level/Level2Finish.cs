using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

public class Level2Finish : MonoBehaviour
{
    public GameObject videoLetter;
    double videoTime2;
    double currentTime2;
    private bool isVideoLetterStarted;
    public AudioSource Music;
    public GameObject redHeart;
    VideoPlayer vp2;
    void Start()
    {
        vp2= videoLetter.GetComponent<VideoPlayer>();
        vp2.url = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Video1.mp4");
        videoTime2 = vp2.clip.length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (redHeart.activeSelf)
        {
            IsGameFinished.Instance.isLevel2Finished = true;

            //Invoke("PlayVideo2", 1);
            StartCoroutine(PlayVideo2());

        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Level 2");
    }
    IEnumerator PlayVideo2()
    {
        yield return new WaitForSeconds(1);
        Music.Stop();
        videoLetter.SetActive(true);
        isVideoLetterStarted = true;

        //if (isVideoBombStarted)
        //{
        currentTime2 += Time.fixedDeltaTime;
        //Debug.Log(currentTime1);
        if (currentTime2 >= videoTime2)
        {
            //videoEndEvent
            videoLetter.SetActive(false);
            currentTime2 = 0;
            isVideoLetterStarted = false;

            SceneManager.LoadScene(5);
            yield return null;
        }
        //}
    }
}
