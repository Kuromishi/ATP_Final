using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;

public class Level1Finish : MonoBehaviour
{
    public GameObject videoBomb;
    double videoTime1;
    double currentTime1;
    private bool isVideoBombStarted;
    public AudioSource Music;

    // Start is called before the first frame update
    void Start()
    {
        videoTime1 = videoBomb.GetComponent<VideoPlayer>().clip.length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().isFinish==true)
        {
            IsGameFinished.Instance.isLevel1Finished = true;
            
            //Invoke("PlayVideo1", 1);
            StartCoroutine(PlayVideo1());

        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    IEnumerator PlayVideo1()
    {
        yield return new WaitForSeconds (1);
        Music.Stop();
        videoBomb.SetActive(true);
        isVideoBombStarted = true;
        
        //if (isVideoBombStarted)
        //{
        currentTime1 += Time.fixedDeltaTime;
            Debug.Log(currentTime1);
            if (currentTime1 >= videoTime1)
            {
                //videoEndEvent
                videoBomb.SetActive(false);
                currentTime1 = 0;
                isVideoBombStarted = false;

                SceneManager.LoadScene(4);
                yield return null;
            }
        //}
    }
}
