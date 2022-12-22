using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseFloatAndDrawLine : MonoBehaviour
{
    public GameObject Line;
    
    public ColorType FloorColor;
    public int RGB;
    public GameObject characterColor;//主角拖进来

    private bool MouseClickCount;

    // Start is called before the first frame update
    void Start()
    {
        FloorColor.rgb = RGB;
        MouseClickCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
        if (this.gameObject == GameManager.Instance.line.GetComponent <DrawLine>().hitobject)
        {
          this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 1);
            if(Input .GetMouseButtonDown(0)&&!MouseClickCount)
            {//左键将混合后的颜色加到主角身上
                characterColor.GetComponent<CharacterComponent>().CharacterColor = ColorType.AddColor(FloorColor, characterColor.GetComponent<CharacterComponent>().CharacterColor);
                string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor.rgb);
                characterColor.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));//主角这里并不能改变自身贴图，需要修改
                Debug.Log(characterColor.GetComponent<CharacterComponent>().CharacterColor.rgb);
                MouseClickCount = true;
            }
            if(Input.GetMouseButtonDown(1))
            {//右键将物体颜色染成主角的颜色
                string name = string.Format("{0}", characterColor.GetComponent<CharacterComponent>().CharacterColor.rgb);
                this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
                Debug.Log(this.GetComponent<MouseFloatAndDrawLine>().FloorColor.rgb);
            }
            
        }else { this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0); }
        
        //Debug.Log("Mouse is over GameObject.");
        //Debug.Log(this.GetComponent<SpriteRenderer>().material.GetFloat("_Highlighted"));
    }

    void OnMouseExit()
    {
        this.GetComponent<SpriteRenderer>().material.SetFloat("_Highlighted", 0);
        //Debug.Log("Mouse is no longer on GameObject.");
        //Debug.Log(this.GetComponent<SpriteRenderer>().material.GetFloat("_Highlighted"));
    }



}
