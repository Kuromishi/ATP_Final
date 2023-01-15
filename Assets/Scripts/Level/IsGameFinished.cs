using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsGameFinished : MonoBehaviour
{
    public static IsGameFinished Instance;

    public bool isLevel1Finished;
    public bool isLevel2Finished;
    public bool isLevel1LeftFinished=false;
    public bool isReloadLevel1 = false;

    private void Awake()
    {
        if(Instance==null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance!=null)
        {
            Destroy(gameObject);
        }
        
    }
}
