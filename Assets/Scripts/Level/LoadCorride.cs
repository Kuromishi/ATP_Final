using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadCorride : MonoBehaviour
{
    public Button play;
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
        play.onClick.AddListener(LoadSceneCF);
    }
    void LoadSceneCF()
    {
        SceneManager.LoadScene(4);
    }
}
