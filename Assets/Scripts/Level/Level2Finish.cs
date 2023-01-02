using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class Level2Finish : MonoBehaviour
{
    public GameObject videoLetter;
    double videoTime2;
    double currentTime2;
    private bool isVideoLetterStarted;

    void Start()
    {
        videoTime2 = videoLetter.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().isFinish == true)
        {
            IsGameFinished.Instance.isLevel2Finished = true;

            Invoke("PlayVideo2", 1);
            
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void PlayVideo2()
    {
        videoLetter.SetActive(true);
        isVideoLetterStarted = true;

        if (isVideoLetterStarted)
        {
            currentTime2 += Time.deltaTime;
            if (currentTime2 >= videoTime2)
            {
                //videoEndEvent
                videoLetter.SetActive(false);
                currentTime2 = 0;
                isVideoLetterStarted = false;
                SceneManager.LoadScene(4);
            }
        }
        
    }
}
