using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Finish : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().isFinish == true)
        {
            IsGameFinished.Instance.isLevel2Finished = true;
            SceneManager.LoadScene(4);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene("Level 2");
    }
}
