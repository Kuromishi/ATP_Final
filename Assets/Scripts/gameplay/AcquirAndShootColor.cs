using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
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

    
    private List<GameObject> tempList = new List<GameObject>();

    [Header("群体消融列表") ]
public List<GameObject> gameObjects1 = new List<GameObject>();
    private bool isListFinished1 = true;
    public List<GameObject> gameObjects2 = new List<GameObject>();
    private bool isListFinished2 = true;
    public List<GameObject> gameObjects3 = new List<GameObject>();
    private bool isListFinished3 = true;
    public List<GameObject> gameObjects4 = new List<GameObject>();
    private bool isListFinished4 = true;
    public List<GameObject> gameObjects5 = new List<GameObject>();
    private bool isListFinished5 = true;




    public Material mat;

    public GameObject characterColor;
    public Dictionary<string, Dictionary<string, string>> rules = new Dictionary<string, Dictionary<string, string>> {
        { "red" , new Dictionary<string, string> {{"blue","purple" }, {"red","red" },{ "black","brown"},{ "green","yellow"},{ "gray","darkred"},{"white","pink" },{"yellow","orange" },{"transp","red" } } },
        {"blue", new Dictionary<string, string> { {"red","purple" },{"blue","blue" },{"gray","darkblue" },{"white","lightblue" },{"transp","blue" } } },
        {"lightblue", new Dictionary<string, string> { { "lightblue", "lightblue" },{"gray","blue" },{"black","darkblue" },{"transp","lightblue" } }},
        {"pink", new Dictionary<string, string> { {"pink","pink" },{"gray","red" },{"black","darkred" },{"transp","pink" } }},
        {"green", new Dictionary<string, string> { {"red","yellow" },{"green","green" },{"gray","lightgreen" },{"white","lightgreen" },{"transp","green" } }},
        {"lightgreen", new Dictionary<string, string> { {"gray","green" },{"lightgreen","lightgreen" },{"black","darkgreen" },{"transp","lightgreen" } }},
        {"black", new Dictionary<string, string> { { "red", "brown" },{"white","gray" },{"black","black" },{"lightgreen","darkgreen" },{"lightblue","darkblue" },{"transp","black" } }},
        {"gray", new Dictionary<string, string> { {"gray","gray" }, { "darkred", "brown" }, { "red","darkred" },{"blue","darkblue" },{"lightblue","blue" },{"green","darkgreen" },{"lightgreen","green" },{"transp","gray" } }},
        {"yellow", new Dictionary<string, string> { {"yellow","yellow" },{"red","orange" },{"transp","yellow" } }},
        {"white", new Dictionary<string, string> { {"white","white" },{"red","pink" },{"darkred","red" },{"brown","darkred" },{"blue","lightblue" },{"green","lightgreen" },{"darkblue","blue" },{"darkgreen","green" },{"black","gray" },{"transp","white" } }},
        {"brown", new Dictionary<string, string> { {"brown","brown" },{"white","darkred" },{"transp","brown" } }},
        {"orange",new Dictionary<string, string> { {"transp","orange" },{"orange","orange" } } },
        {"purple",new Dictionary<string, string> { {"transp","purple" },{"purple","purple" } } },

        {"darkred", new Dictionary<string, string> { { "darkred", "darkred" }, { "gray", "brown" }, { "white", "red" }, { "transp", "darkred" } }},
        {"darkblue", new Dictionary<string, string> { { "darkblue", "darkblue" }, { "white", "blue" }, { "transp", "darkblue" } }},
        {"darkgreen", new Dictionary<string, string> { { "darkgreen", "darkgreen" }, { "white", "green" }, { "transp", "darkgreen" } }}

    };

    public Dictionary<string, string > huburules = new Dictionary<string, string >
    {
        {"blue", "orange"},{"orange","blue"},{"yellow","purple"},{"purple","yellow"},{"red","green"},{"green","red"},{"gray","white"},{"white","gray"}
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
        //Debug.Log(isFinishedTemp);
        //Debug.Log(isFinish);
        if(isFinishedTemp)
        {
            isFinish = true;
            //这里引用动画脚本
        }

        //1
        isListFinished1 = true;
        foreach (GameObject i in gameObjects1)
        {
            if(i.GetComponent <MouseFloatAndDrawLine >().FloorColor .Equals (i.GetComponent <MouseFloatAndDrawLine >().correctColor))
            {

            }else { isListFinished1 = false; }
        }
        //Debug.Log(isListFinished1);
        if(isListFinished1)
        {
foreach (GameObject j in gameObjects1)
        {
            StartCoroutine(StartDesolve(j));
        }
            gameObjects1.Clear();
        }
        //2
        isListFinished2 = true;
        foreach (GameObject i in gameObjects2)
        {
            if (i.GetComponent<MouseFloatAndDrawLine>().FloorColor.Equals(i.GetComponent<MouseFloatAndDrawLine>().correctColor))
            {

            }
            else { isListFinished2 = false; }
        }
        if (isListFinished2)
        {
            foreach (GameObject j in gameObjects2)
            {
                StartCoroutine(StartDesolve(j));
            }
            gameObjects2.Clear();
        }
        //3
        isListFinished3 = true;
        foreach (GameObject i in gameObjects3)
        {
            if (i.GetComponent<MouseFloatAndDrawLine>().FloorColor.Equals(i.GetComponent<MouseFloatAndDrawLine>().correctColor))
            {

            }
            else { isListFinished3 = false; }
        }
        if (isListFinished3)
        {
            foreach (GameObject j in gameObjects3)
            {
                StartCoroutine(StartDesolve(j));
            }
            gameObjects3.Clear();
        }
        //4
        isListFinished4 = true;
        foreach (GameObject i in gameObjects4)
        {
            if (i.GetComponent<MouseFloatAndDrawLine>().FloorColor.Equals(i.GetComponent<MouseFloatAndDrawLine>().correctColor))
            {

            }
            else { isListFinished4 = false; }
        }
        if (isListFinished4)
        {
            foreach (GameObject j in gameObjects4)
            {
                StartCoroutine(StartDesolve(j));
            }
            gameObjects4.Clear();
        }
        //5
        isListFinished5 = true;
        foreach (GameObject i in gameObjects5)
        {
            if (i.GetComponent<MouseFloatAndDrawLine>().FloorColor.Equals(i.GetComponent<MouseFloatAndDrawLine>().correctColor))
            {

            }
            else { isListFinished5 = false; }
        }
        if (isListFinished5)
        {
            foreach (GameObject j in gameObjects5)
            {
                StartCoroutine(StartDesolve(j));
            }
            gameObjects5.Clear();
        }

    }

    IEnumerator StartDesolve(GameObject i)
    {
        float duration = 0;
        i.GetComponent<SpriteRenderer>().material = mat;
        i.GetComponent<SpriteRenderer>().material.SetFloat("_DissolveThreshold", 0.0f);
        yield return null;
        while (true)
        {
            duration += Time.deltaTime;
            if (duration > 1.0f)
            {
                Destroy(i);
                break;
            }
            float t_val = duration;
            i.GetComponent<SpriteRenderer>().material.SetFloat("_DissolveThreshold", t_val);
            yield return null;
        }
    }

    private void Awake()
    {
        image.sprite = (Sprite)Resources.Load("transp", typeof(Sprite));
        
        GameObject[] floorA= GameObject.FindGameObjectsWithTag("floor");
        GameObject[] influA= GameObject.FindGameObjectsWithTag("influ");
        
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

    public string ReturnContrastColor(string colorname)
    {
        string a = huburules[colorname];
        return a;
    }
}
