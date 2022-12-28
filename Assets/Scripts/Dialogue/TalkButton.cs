using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{


    public GameObject messageUI;
    public NPCStateSwitch npcSwitch;


    [Header("NPC State")]
    public GameObject uiButton;
    public bool isGirlTalk;
    public bool isContrastTalk;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        //bool isActive = uiButton.activeSelf;
        //Debug.Log(isActive);

        if (uiButton.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            messageUI.SetActive(true);
            
        }



    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
            if (other.GetComponentInParent<NPCGirl>() != null)
            {
                isGirlTalk = true;
            }
           
            if (other.GetComponentInParent<NPCContrast>() != null)
            {
                isContrastTalk = true;
            }

           uiButton.SetActive(true);


    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<NPCGirl>() != null)
        {
            isGirlTalk = true;
        }

        if (other.GetComponentInParent<NPCContrast>() != null)
        {
            isContrastTalk = true;
        }

        uiButton.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D other)
    {

            isGirlTalk = false;
            isContrastTalk = false;
            uiButton.SetActive(false);

    }
}
