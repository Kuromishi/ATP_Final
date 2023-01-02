using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AcquirAndShootColor : MonoBehaviour 
{
    //in the eventsystem object, make the rules of mix color, define the way to finish this level
    public Image image;
    public Button skip;
    

    [SerializeField ]private GameObject[] allObj;
    public bool isFinish = false;
    private bool isFinishedTemp = true;
    private int sceneNum;

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

    public GameObject blood;
    private Animator anim_knife;
    private Animator anim_blood;
    public GameObject knife;


    public Material mat;

    public GameObject characterColor;
    public Dictionary<string, Dictionary<string, string>> rules = new Dictionary<string, Dictionary<string, string>> {
        { "red" , new Dictionary<string, string> {{"blue","purple" }, {"red","red" },{ "black","brown"},{ "green","yellow"},{ "gray","darkred"},{"white","lightred" },{"yellow","orange" },{"transp","red" } } },
        {"blue", new Dictionary<string, string> { {"red","purple" },{ "orange", "brown" },{ "blue","blue" },{"gray","darkblue" },{"white","lightblue" },{"transp","blue" }, { "yellow", "green" } } },
        {"lightblue", new Dictionary<string, string> { { "lightblue", "lightblue" }, { "yellow", "lightgreen" },{ "gray","blue" },{"black","darkblue" },{"transp","lightblue" } }},
        {"lightred", new Dictionary<string, string> { { "lightred", "lightred" },{"gray","red" },{"black","darkred" },{"transp","lightred" },{ "purple", "pink" } }},
        {"green", new Dictionary<string, string> { {"red","yellow" },{"green","green" },{"gray","lightgreen" },{"white","lightgreen" },{"transp","green" } }},
        {"lightgreen", new Dictionary<string, string> { {"gray","green" },{"lightgreen","lightgreen" },{"black","darkgreen" },{"transp","lightgreen" } }},
        {"black", new Dictionary<string, string> { { "red", "brown" },{"white","gray" },{"black","black" },{"lightgreen","darkgreen" },{"lightblue","darkblue" },{"transp","black" } }},
        {"gray", new Dictionary<string, string> { {"gray","gray" }, { "pink", "darkred" }, { "lightred", "red" }, { "darkred", "brown" }, { "red","darkred" },{"blue","darkblue" },{"lightblue","blue" },{"green","darkgreen" },{"lightgreen","green" },{"transp","gray" } }},
        {"yellow", new Dictionary<string, string> { {"yellow","yellow" }, { "lightblue", "lightgreen" },{ "red","orange" },{"transp","yellow" },{"blue","green" } }},
        {"white", new Dictionary<string, string> { {"white","white" },{"red","lightred" },{"darkred","red" },{"brown","darkred" },{"blue","lightblue" },{"green","lightgreen" },{"darkblue","blue" },{"darkgreen","green" },{"black","gray" },{"transp","white" } }},
        {"brown", new Dictionary<string, string> { {"brown","brown" },{"white","darkred" },{"transp","brown" } }},
        {"orange",new Dictionary<string, string> { {"transp","orange" },{"orange","orange" }, { "blue", "brown" } } },
        {"purple",new Dictionary<string, string> { {"transp","purple" },{"purple","purple" }, { "lightred", "pink" } } },
        {"pink",new Dictionary<string, string> { {"transp","pink" },{"pink","pink" }, { "gray", "darkred" } } },
        {"darkred", new Dictionary<string, string> { { "darkred", "darkred" }, { "gray", "brown" }, { "white", "red" }, { "transp", "darkred" } }},
        {"darkblue", new Dictionary<string, string> { { "darkblue", "darkblue" }, { "white", "blue" }, { "transp", "darkblue" } }},
        {"darkgreen", new Dictionary<string, string> { { "darkgreen", "darkgreen" }, { "white", "green" }, { "transp", "darkgreen" } }}

    };

    public Dictionary<string, string > huburules = new Dictionary<string, string >
    {
        {"blue", "orange"},{"orange","blue"},{"yellow","purple"},{"purple","yellow"},{"red","green"},{"green","red"},{"gray","white"},{"white","gray"},
        {"darkred","darkgreen"},{"darkgreen","darkred"},{"lightgreen","lightred"},{"lightred","lightgreen"}
    };

    public void RemoveFromList(GameObject go)
    {
        var allObjectList = allObj.ToList();
        allObjectList.Remove(go);
        allObj = allObjectList.ToArray();
    }

    private void Update()
    {
        string name = string.Format("{0}/{1}", sceneNum, characterColor.GetComponent<CharacterComponent>().CharacterColor);
        image.sprite = (Sprite)Resources.Load(name, typeof(Sprite));

        isFinishedTemp = true;
        for(int i=0;i<allObj.Length; i++)
        {
            if(allObj[i].GetComponent <MouseFloatAndDrawLine >().FloorColor .Equals (allObj[i].GetComponent<MouseFloatAndDrawLine>().correctColor))
            {
                
            }else { isFinishedTemp = false; };
        }
        if(isFinishedTemp)
        {
            isFinish = true;
            //这里引用动画脚本
            if(knife != null)
            {
anim_blood.SetBool("moving", true);
            anim_knife.SetBool("moving", true);
            }
            
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
                GameManager.Instance.lightChange.RemoveFromList(i);
                GameManager.Instance.acquirAndShootColor.RemoveFromList(i);
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
        string name = string.Format("{0}/{1}", sceneNum, "transp");
        image.sprite = (Sprite)Resources.Load(name, typeof(Sprite));

        
        GameObject[] dissolveListA = GameObject.FindGameObjectsWithTag("dissolveList");
        GameObject[] influA = GameObject.FindGameObjectsWithTag("influ");
        GameObject[] dissolveA = GameObject.FindGameObjectsWithTag("dissolve");
        tempList.AddRange(dissolveListA);
        tempList.AddRange(dissolveA);
        
        tempList.AddRange(influA);
        allObj = tempList.ToArray();

        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        GameManager.Instance.acquirAndShootColor = this;
        if(knife != null)
        {
anim_knife = knife.GetComponent<Animator>();
        anim_blood = blood.GetComponent<Animator>();
        }
        
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
    public void OnEnable()
    {
        skip.onClick.AddListener(skipF);
        
    }
    void skipF()
    {
        SceneManager.LoadScene(4);
    }
}
