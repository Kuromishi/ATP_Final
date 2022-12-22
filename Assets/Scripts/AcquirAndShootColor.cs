using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class AcquirAndShootColor : MonoBehaviour 
{
    //直接替换纹理，要替换的纹理都放在resources文件夹下
    public Dictionary<string, string> ColorsRules = new Dictionary<string, string> { };//前一个是颜色索引，第二个是纹理名称
    public TextAsset ColorsRuleSText;
    private string Key_Color;
    private string Value_Color;

    private string aimcolor;
    private string selfcolor;
    List<Material> Mat = new List<Material>();

    public GameObject Floor;
    void LoadColorText()
    {
        string[] everyLine = ColorsRuleSText.text.Split('\n');
        for(int i=0;i<everyLine.Length-1; i++)
        {
            string[] everypart = everyLine[i].Split('\t');
            ColorsRules.Add(Convert.ToString(everypart[0]), everypart[1]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i < 20; i++)
        {
            Mat[i] = Resources.Load<Material>("mingcheng");//将纹理储存到
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    }
