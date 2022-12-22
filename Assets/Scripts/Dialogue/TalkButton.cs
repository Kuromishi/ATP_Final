using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{
    public GameObject uiButton;
    public GameObject messageUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if(uiButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            messageUI.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        uiButton.SetActive(true);
        //Debug.Log("Entered");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        uiButton.SetActive(false);
    }
}
