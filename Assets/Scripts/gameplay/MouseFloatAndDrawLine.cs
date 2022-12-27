using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseFloatAndDrawLine : MonoBehaviour
{
    //real shooting color and recieve color
    
    public string FloorColor;
    public string correctColor;
    private bool isequel;
    private GameObject characterColor;//主角拖进来

    
    //private bool MouseClickCount;

    // Start is called before the first frame update
    void Start()
    {
        //FloorColor.rgb = RGB;
        characterColor = GameManager.Instance.characterColor;
        //MouseClickCount = false;
        if(this.tag == "floor"||this.tag =="influ" || this.tag == "dissolve" || this.tag == "dissolveList")
        {
              this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(FloorColor, typeof(Sprite));
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (FloorColor.Equals(correctColor))
        {
            isequel = true;
        }else { isequel = false; }

    }
    void OnMouseOver()
    {
        if(!isequel)
        {
if (this.gameObject == GameManager.Instance.line.GetComponent <DrawLine>().hitobject)
        {
          this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 1);
            if(Input .GetMouseButtonDown(0)&&this .tag !="influ" && this.tag != "dissolve"&& this.tag != "contrast")
            {//左键将混合后的颜色加到主角身上
                characterColor.GetComponent<CharacterComponent>().CharacterColor = GameObject .Find ("EventSystem").GetComponent <AcquirAndShootColor >().ReturnColor(FloorColor, characterColor.GetComponent<CharacterComponent>().CharacterColor);
            }else if(Input.GetMouseButtonDown(0) && this.tag == "contrast")
                {
                    characterColor.GetComponent<CharacterComponent>().CharacterColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnContrastColor(characterColor.GetComponent<CharacterComponent>().CharacterColor);
                }
            if(Input.GetMouseButtonDown(1)&&this .tag !="status"&& characterColor.GetComponent<CharacterComponent>().CharacterColor!="transp" && this.tag != "contrast")
            {//右键将物体颜色染成主角的颜色
                    FloorColor = characterColor.GetComponent<CharacterComponent>().CharacterColor;
                string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor);
                this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
                
            }
            
        }else { this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0); }
        
        
        }
        
    }

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0);
        //Debug.Log("Mouse is no longer on GameObject.");
        //Debug.Log(this.GetComponent<SpriteRenderer>().material.GetFloat("_Highlighted"));
    }



}
