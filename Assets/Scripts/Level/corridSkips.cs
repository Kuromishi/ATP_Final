using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class corridSkips : MonoBehaviour
{
    public Button skip;
    public Button skip2;
    public GameObject  video1;
    public GameObject  video2;

    public character_45du character45Degree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnEnable()
    {
        skip.onClick.AddListener(skipF);
        skip2.onClick.AddListener(skipF1);

    }
    void skipF()
    {
        video1.SetActive(false);
        character45Degree.canMove = true;

    }
    void skipF1()
    {
        video2.SetActive(false);
        character45Degree.canMove = true;

    }
}
