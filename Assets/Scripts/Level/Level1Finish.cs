using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using UnityEngine.UI;
using System.IO;

public class Level1Finish : MonoBehaviour
{
    public GameObject videoBomb;
    double videoTime1;
    double currentTime1;
    private bool isVideoBombStarted;
    public AudioSource Music;
    VideoPlayer vp1;
    public List<GameObject> leftDissolve;
    public GameObject character;
    
    // Start is called before the first frame update
    void Start()
    {
        vp1= videoBomb.GetComponent<VideoPlayer>();
        vp1.url = Path.Combine(UnityEngine.Application.streamingAssetsPath, "Video_Bomb.mp4");
        videoTime1 = vp1.clip.length;
    }
    private void Update()
    {
        foreach (GameObject obj in leftDissolve)
        {
            if(obj==null)
            {
                leftDissolve.Remove(obj);
            }
        }
        if(leftDissolve .Count == 0)
        {
            IsGameFinished.Instance.isLevel1LeftFinished = true;
        }
        if (IsGameFinished.Instance.isLevel1LeftFinished == true)
        {
            character.transform.position = new Vector3(-3.2f, -0.5f, character.transform.position.z);
            foreach (GameObject obj in leftDissolve)
            {
                GameManager.Instance.lightChange.RemoveFromList(obj);
                GameManager.Instance.acquirAndShootColor.RemoveFromList(obj);
                Destroy(obj);
            }
        }
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
            //Debug.Log(currentTime1);
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
