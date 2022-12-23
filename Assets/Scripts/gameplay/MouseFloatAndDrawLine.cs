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
            if(Input .GetMouseButtonDown(0))
            {//左键将混合后的颜色加到主角身上
                Debug.Log(FloorColor);
                Debug.Log(characterColor.GetComponent<CharacterComponent>().CharacterColor);
                characterColor.GetComponent<CharacterComponent>().CharacterColor = GameObject .Find ("EventSystem").GetComponent <AcquirAndShootColor >().ReturnColor(FloorColor, characterColor.GetComponent<CharacterComponent>().CharacterColor);
                string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor);
                
                Debug.Log(characterColor.GetComponent<CharacterComponent>().CharacterColor);
                
            }
            if(Input.GetMouseButtonDown(1))
            {//右键将物体颜色染成主角的颜色
                    FloorColor = characterColor.GetComponent<CharacterComponent>().CharacterColor;
                string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor);
                this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
                Debug.Log(this.GetComponent<MouseFloatAndDrawLine>().FloorColor);
            }
            
        }else { this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0); }
        
        //Debug.Log("Mouse is over GameObject.");
        //Debug.Log(this.GetComponent<SpriteRenderer>().material.GetFloat("_Highlighted"));
        }
        
    }

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0);
        //Debug.Log("Mouse is no longer on GameObject.");
        //Debug.Log(this.GetComponent<SpriteRenderer>().material.GetFloat("_Highlighted"));
    }



}
