using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AcquirAndShootColor : MonoBehaviour 
{
    //in the eventsystem object, make the rules of mix color, define the way to finish this level
    public Image image;

    private GameObject[] allObj;
    public bool isFinish = false;
    private bool isFinishedTemp = true;

    public GameObject characterColor;
    public Dictionary<string, Dictionary<string, string>> rules = new Dictionary<string, Dictionary<string, string>> {
        { "red" , new Dictionary<string, string> {{"blue","purple" }, {"red","red" },{ "black","brown"},{ "green","yellow"},{ "gray","darkred"},{"white","pink" },{"yellow","orange" },{"transp","red" } } },
        {"blue", new Dictionary<string, string> { {"red","purple" },{"blue","blue" },{"gray","darkblue" },{"white","lightblue" },{"transp","blue" } } },
        {"lightblue", new Dictionary<string, string> { { "lightblue", "lightblue" },{"gray","blue" },{"black","darkblue" },{"transp","lightblue" } }},
        {"pink", new Dictionary<string, string> { {"pink","pink" },{"gray","red" },{"black","darkred" },{"transp","pink" } }},
        {"green", new Dictionary<string, string> { {"red","yellow" },{"green","green" },{"gray","lightgreen" },{"white","lightgreen" },{"transp","green" } }},
        {"lightgreen", new Dictionary<string, string> { {"gray","green" },{"lightgreen","lightgreen" },{"black","darkgreen" },{"transp","lightgreen" } }},
        {"black", new Dictionary<string, string> { { "red", "brown" },{"white","gray" },{"black","black" },{"lightgreen","darkgreen" },{"lightblue","darkblue" },{"transp","black" } }},
        {"gray", new Dictionary<string, string> { {"gray","gray" },{"red","darkred" },{"blue","darkblue" },{"lightblue","blue" },{"green","darkgreen" },{"lightgreen","green" },{"transp","gray" } }},
        {"yellow", new Dictionary<string, string> { {"yellow","yellow" },{"red","orange" },{"transp","yellow" } }},
        {"white", new Dictionary<string, string> { {"white","white" },{"red","pink" },{"darkred","red" },{"brown","darkred" },{"blue","lightblue" },{"green","lightgreen" },{"darkblue","blue" },{"darkgreen","green" },{"black","gray" },{"transp","white" } }},
        {"brown", new Dictionary<string, string> { {"brown","brown" },{"white","darkred" },{"transp","brown" } }},
        
        {"darkred", new Dictionary<string, string> { { "darkred", "darkred" }, { "white", "red" }, { "transp", "darkred" } }},
        {"darkblue", new Dictionary<string, string> { { "darkblue", "darkblue" }, { "white", "blue" }, { "transp", "darkblue" } }},
        {"darkgreen", new Dictionary<string, string> { { "darkgreen", "darkgreen" }, { "white", "green" }, { "transp", "darkgreen" } }}

    };
    private void Update()
    {
        string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor);
        image.sprite = (Sprite)Resources.Load(name, typeof(Sprite));
        isFinishedTemp = true;
        for(int i=0;i<allObj.Length; i++)
        {
            if(allObj[i].GetComponent <MouseFloatAndDrawLine >().FloorColor .Equals (allObj[i].GetComponent<MouseFloatAndDrawLine>().correctColor))
            {
                
            }else { isFinishedTemp = false; };
        }
        Debug.Log(isFinishedTemp);
        Debug.Log(isFinish);
        if(isFinishedTemp)
        {
            isFinish = true;
            //这里引用动画脚本
        }
    }
    private void Awake()
    {
        image.sprite = (Sprite)Resources.Load("0", typeof(Sprite));
        
        GameObject[] floorA= GameObject.FindGameObjectsWithTag("floor");
        GameObject[] influA= GameObject.FindGameObjectsWithTag("influ");
        List<GameObject> tempList = new List<GameObject>();
        tempList.AddRange(floorA);
        tempList.AddRange(influA);
        allObj = tempList.ToArray();
    }
    public string ReturnColor(string colorname1, string colorname2)
    {
        Dictionary<string, string> a = rules[colorname1];
        string b = a[colorname2];
        return b;
    }
}
