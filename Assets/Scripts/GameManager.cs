using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //single object model
    public static GameManager Instance { get; private set; }
    public int value { get; set; } = 0;
    public GameObject line;
    public GameObject characterColor;
    private void Awake()
    {
        if(Instance == null)
        {
Instance = this;
        DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
