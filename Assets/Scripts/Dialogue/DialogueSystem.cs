using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public Text textLabel;

    public TextAsset textFile;
    public int index;

    public float textSpeed;
    private bool textFinished;
    private bool cancelTyping;

    List<string> textList = new List<string>();

    public Animator anim_NPC;

    public CharacterComponent characterDetective;
    public TalkButton talkButton;

    //void Start()
    //{
    //    GetTextFromFile(textFile);

    //}

    void Awake()
    {
        
    }

    private void OnEnable() //刚启用时  //OnEnable会在Start之前调用
    {
        //textLabel.text = textList[index];
        //index++;
        if(textFile)
        {
            GetTextFromFile(textFile);
        }
        
        talkButton.uiButton.SetActive(false);

        StartCoroutine(MovingTextUI());
        anim_NPC.SetBool("isTalking", true);
        characterDetective.isTalking = true;
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && index == textList.Count) //如果输出到最后一个部分
        {
            gameObject.SetActive(false);
            index = 0;

            anim_NPC.SetBool("isTalking", false);
            characterDetective.isTalking = false;
            talkButton.uiButton.SetActive(true);
        }
        //if (Input.GetKeyDown(KeyCode.E) && textFinished==true)
        //{
        //    //textLabel.text = textList[index];
        //    //index++;

        //    StartCoroutine(MovingTextUI());
        //    //characterDetective.isTalking = true;
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(textFinished && !cancelTyping)
            {
                StartCoroutine(MovingTextUI());
            }
            else if(!textFinished) //开始coroutine
            {
                cancelTyping = !cancelTyping; //每摁下摁键就改变值（在打字的时候，摁下摁键==cancel）
            }
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineData = file.text.Split('\n'); 

        foreach(var line in lineData)
        {
            textList.Add(line);
        }
    }

    IEnumerator MovingTextUI()
    {
        textFinished = false;  //一行文字结束后，才可以进行第二行字
        textLabel.text = ""; //每行打完列表清空，再打下一行

        //for(int i = 0; i < textList[index].Length; i++)  //获得一行中的每一个字符，获得当前行的长度
        //{
        //    textLabel.text += textList[index][i];  //第i个字符

        //    yield return new WaitForSeconds(textSpeed);
        //}

        int letter = 0;
        while(!cancelTyping && letter < textList[index].Length)
        {
            textLabel.text += textList[index][letter];
            letter++;
            yield return new WaitForSeconds(textSpeed);
        }

        textLabel.text = textList[index];
        cancelTyping = false;

        textFinished = true;
        index++;
    }
}
