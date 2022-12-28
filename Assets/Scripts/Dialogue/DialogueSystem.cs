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

    private void OnEnable() //������ʱ  //OnEnable����Start֮ǰ����
    {
        //textLabel.text = textList[index];
        //index++;
        GetTextFromFile(textFile);

        StartCoroutine(MovingTextUI());
        anim_NPC.SetBool("isTalking", true);
        characterDetective.isTalking = true;
        talkButton.uiButton.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && index == textList.Count) //�����������һ������
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
            else if(!textFinished) //��ʼcoroutine
            {
                cancelTyping = !cancelTyping; //ÿ���������͸ı�ֵ���ڴ��ֵ�ʱ����������==cancel��
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
        textFinished = false;  //һ�����ֽ����󣬲ſ��Խ��еڶ�����
        textLabel.text = ""; //ÿ�д����б���գ��ٴ���һ��

        //for(int i = 0; i < textList[index].Length; i++)  //���һ���е�ÿһ���ַ�����õ�ǰ�еĳ���
        //{
        //    textLabel.text += textList[index][i];  //��i���ַ�

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
