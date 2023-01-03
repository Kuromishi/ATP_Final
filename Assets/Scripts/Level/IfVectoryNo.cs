using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IfVectoryNo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        this.GetComponent<Button>().onClick.AddListener(GoBack);
    }
    void GoBack()
    {
        SceneManager.LoadScene(0);
        IsGameFinished.Instance.isLevel1Finished = false;
        IsGameFinished.Instance.isLevel2Finished = false;
    }
}
