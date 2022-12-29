using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButton : MonoBehaviour
{


    public GameObject messageUI;
    public NPCStateSwitch npcSwitch;

    [Header("Puzzle")]
    public GameObject theThing;
    public GameObject toFind;
    public GameObject puzzleDoor;
    public GameObject bodyFound;

    [Header("NPC State")]
    public GameObject uiButton;
    public bool isGirlTalk;
    public bool isContrastTalk;
    public bool isNonsense1Talk;
    public bool isNonsense2Talk;
    public bool isToFindTalk;
    public bool isBodyTalk;



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

             if (other.GetComponentInParent<NPC_Nonsense_1>() != null)
             {
                 isNonsense1Talk = true;
             }

            if (other.GetComponentInParent<NPC_Nonsense_2>() != null)
            {
                 isNonsense2Talk = true;
            }

            if(other.GetComponentInParent<ToFind>() != null)
            {
                 isToFindTalk = true;
             }

        if (other.GetComponentInParent<Body>() != null)
        {
            isBodyTalk = true;
        }

        uiButton.SetActive(true);
    
             if (other.GetComponentInParent<SmthToGet>() != null && Input.GetKeyDown(KeyCode.E))
             {
                     Destroy(theThing);
                    toFind.SetActive(false);
                     puzzleDoor.SetActive(false);
                    bodyFound.SetActive(true);
             }
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
        if (other.GetComponentInParent<NPC_Nonsense_1>() != null)
        {
            isNonsense1Talk = true;
        }

        if (other.GetComponentInParent<NPC_Nonsense_2>() != null)
        {
            isNonsense2Talk = true;
            
        }

        if (other.GetComponentInParent<ToFind>() != null)
        {
            isToFindTalk = true;
        }

        if (other.GetComponentInParent<Body>() != null)
        {
            isBodyTalk = true;
        }

        uiButton.SetActive(true);

        if (other.GetComponentInParent<SmthToGet>() != null && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(theThing);
            toFind.SetActive(false);
            puzzleDoor.SetActive(false);
            bodyFound.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {

        isGirlTalk = false;
        isContrastTalk = false;
        isNonsense1Talk = false;
        isNonsense2Talk = false;
        isToFindTalk = false;
        isBodyTalk = false;
        uiButton.SetActive(false);

    }
}
