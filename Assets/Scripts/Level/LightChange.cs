using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LightChange : MonoBehaviour
{
    public float lightOffValue;
    public float lightOnValue;
    public PPChange ppChange;
    private bool isLightOn = true;
    public bool inTrigger = false;
    [SerializeField ] private GameObject[] AllObj;

    public GameObject iconE;

    private int sceneNum;
    public Dictionary<string, Dictionary<string, string>> rules = new Dictionary<string, Dictionary<string, string>> { };

    private void Awake()
    {
        GameObject[] floorA = GameObject.FindGameObjectsWithTag("floor");
        GameObject[] dissolveListA = GameObject.FindGameObjectsWithTag("dissolveList");
        GameObject[] statusA = GameObject.FindGameObjectsWithTag("status");
        GameObject[] dissolveA = GameObject.FindGameObjectsWithTag("dissolve");
        List<GameObject> tempList = new List<GameObject>();
        tempList.AddRange(floorA);
        tempList.AddRange(dissolveListA);
        tempList.AddRange(statusA);
        tempList.AddRange(dissolveA);
        AllObj = tempList.ToArray();

        rules = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().rules;
        sceneNum = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        GameManager.Instance.lightChange = this;
    }

    public void RemoveFromList(GameObject go)
    {
        var allObjectList = AllObj.ToList();
        allObjectList.Remove(go);
        AllObj =   allObjectList.ToArray(); 
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inTrigger)
        {
            if(isLightOn)
            {
                isLightOn = false;
                ppChange.LightOff();
                //加灰色
                for (int i = 0; i < AllObj.Length; i++)
                {
                    if (AllObj[i] != null&&rules [AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor].ContainsKey ("gray")&& AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor!= AllObj[i].GetComponent<MouseFloatAndDrawLine>().correctColor)
                    {
                        AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnColor(AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor, "gray");
                        string name = string.Format("{0}/{1}", sceneNum, AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor);
                        AllObj[i].GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
                    }
                }
            }
            else
            {
                isLightOn = true;
                ppChange.LightOn();
                //加白色
                for (int i = 0; i < AllObj.Length; i++)
                {
                    if (AllObj[i] != null && rules[AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor].ContainsKey("white") && AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor != AllObj[i].GetComponent<MouseFloatAndDrawLine>().correctColor)
                    {
                        AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnColor(AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor, "white");
                        string name = string.Format("{0}/{1}", sceneNum, AllObj[i].GetComponent<MouseFloatAndDrawLine>().FloorColor);
                        AllObj[i].GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
                    }
                }
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<CharacterComponent>() != null)
        {
            inTrigger = true;
            iconE.SetActive(true);
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponentInParent<CharacterComponent>() != null)
        {
            inTrigger = true;
            iconE.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inTrigger = false;
        iconE.SetActive(false);
    }


}
