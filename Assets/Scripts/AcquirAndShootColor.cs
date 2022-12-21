using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AcquirAndShootColor : MonoBehaviour
{
    public Dictionary<string, float> ColorsRules = new Dictionary<string, float> { };
    public TextAsset ColorsRuleSText;
    private string Key_Color;
    private float Value_Color;

    private Color aimcolor;
    private Color selfcolor;
    //rules.Add(IRules_Key.text[0], IRules_Value.text);
    void LoadColorText()
    {
        string[] everyLine = ColorsRuleSText.text.Split('\n');
        for(int i=0;i<everyLine.Length-1; i++)
        {
            string[] everypart = everyLine[i].Split('\t');
            //ColorsRules.Add(Convert.ToString(everypart[0]), everypart[1]);
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
