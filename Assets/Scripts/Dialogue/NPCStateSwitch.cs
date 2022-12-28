using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateSwitch : MonoBehaviour
{
    [Header("UI Button")]
    public GameObject uiButton_Girl;
    public GameObject uiButton_ContrastNPC;
    public GameObject uiButton_Nobody;

    [Header("Textfile")]
    public TextAsset textFile_Girl;
    public TextAsset textFile_ContrastNPC;
    public TextAsset textFile_Nobody;


    [Header("Other scripts")]
    public TalkButton talkButton;
    public DialogueSystem dialogueSystem;

    public enum NPCState
    {
        Nobody,
        Girl,
        ContrastNPC
    }

    [Header("NPC State")]
    public NPCState State = NPCState.Nobody;

    private void Update()
    {
        if (talkButton.isGirlTalk)
            State = NPCState.Girl;

        else if (talkButton.isContrastTalk)
            State = NPCState.ContrastNPC;
        
        else
            State = NPCState.Nobody;




        switch (State)
        {
            case NPCState.Girl:

                talkButton.uiButton = uiButton_Girl;
                dialogueSystem.textFile = textFile_Girl;

                break;

            case NPCState.ContrastNPC:

                talkButton.uiButton = uiButton_ContrastNPC;
                dialogueSystem.textFile = textFile_ContrastNPC;
                break;

            case NPCState.Nobody:

                talkButton.uiButton= uiButton_Nobody;
                dialogueSystem.textFile = textFile_Nobody;
                break;
        }
    }
}
