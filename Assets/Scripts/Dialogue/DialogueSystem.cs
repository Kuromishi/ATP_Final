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

    List<string> textList = new List<string>();

    //void Start()
    //{
    //    GetTextFromFile(textFile);
    //}

    void Awake()
    {
        GetTextFromFile(textFile);
    }

    private void OnEnable() //������ʱ  //OnEnable����Start֮ǰ����
    {
        //textLabel.text = textList[index];
        //index++;

        StartCoroutine(MovingTextUI());

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && index == textList.Count) //�����������һ������
        {
            gameObject.SetActive(false);
            index = 0;
        } 
        if(Input.GetKeyDown(KeyCode.E) && textFinished==true)
        {
            //textLabel.text = textList[index];
            //index++;

            StartCoroutine(MovingTextUI());
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

        for(int i = 0; i < textList[index].Length; i++)  //���һ���е�ÿһ���ַ�����õ�ǰ�еĳ���
        {
            textLabel.text += textList[index][i];  //��i���ַ�

            yield return new WaitForSeconds(textSpeed);
        }

        textFinished = true;
        index++;
    }
}
