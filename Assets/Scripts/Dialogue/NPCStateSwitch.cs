using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStateSwitch : MonoBehaviour
{
    [Header("UI Button")]
    public GameObject uiButton_Girl;
    public GameObject uiButton_ContrastNPC;
    public GameObject uiButton_Nonsense1;
    public GameObject uiButton_Nonsense2;
    public GameObject uiButton_Nobody;
    public GameObject uiButton_Body;

    [Header("Textfile")]
    public TextAsset textFile_Girl;
    public TextAsset textFile_ContrastNPC;
    public TextAsset textFile_Nonsense1;
    public TextAsset textFile_Nonsense2;
    public TextAsset textFile_Nobody;
    public TextAsset textFile_ToFind;
    public TextAsset textFile_Body;


    [Header("Other scripts")]
    public TalkButton talkButton;
    public DialogueSystem dialogueSystem;

    public enum NPCState
    {
        Nobody,
        Girl,
        ContrastNPC,
        Nonsense1,
        Nonsense2,
        ToFind,
        Body
    }

    [Header("NPC State")]
    public NPCState State = NPCState.Nobody;

    private void Update()
    {
        if (talkButton.isGirlTalk)
            State = NPCState.Girl;

        else if (talkButton.isContrastTalk)
            State = NPCState.ContrastNPC;

        else if (talkButton.isNonsense1Talk)
            State = NPCState.Nonsense1;

        else if (talkButton.isNonsense2Talk)
            State = NPCState.Nonsense2;

        else if (talkButton.isToFindTalk)
            State = NPCState.ToFind;

        else if (talkButton.isBodyTalk)
            State = NPCState.Body;

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

            case NPCState.Nonsense1:

                talkButton.uiButton = uiButton_Nonsense1;
                dialogueSystem.textFile = textFile_Nonsense1;
                break;

            case NPCState.Nonsense2:

                talkButton.uiButton = uiButton_Nonsense2;
                dialogueSystem.textFile = textFile_Nonsense2;
                break;

            case NPCState.ToFind:

                talkButton.uiButton = uiButton_Body;
                dialogueSystem.textFile = textFile_ToFind;
                break;

            case NPCState.Body:

                talkButton.uiButton = uiButton_Body;
                dialogueSystem.textFile = textFile_Body;
                break;

            case NPCState.Nobody:

                talkButton.uiButton= uiButton_Nobody;
                dialogueSystem.textFile = textFile_Nobody;
                break;
        }
    }
}
