using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MouseFloatAndDrawLine : MonoBehaviour
{
    //real shooting color and recieve color
    
    public string FloorColor;
    public string correctColor;
    private bool isequel;
    private GameObject characterColor;//主角拖进来
    private int sceneNum;

    public GameObject redHeart;
    //public SpriteRenderer whiteheartRender;

    public AudioSource source;
    public AudioClip shoot;
    public AudioClip absorb;

    public GameObject particleAbsorb;
    public GameObject particleShoot;
    private float pSpeed=2.0f;

    //private bool MouseClickCount;

    // Start is called before the first frame update
    void Start()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        //FloorColor.rgb = RGB;
        characterColor = GameManager.Instance.characterColor;
        //MouseClickCount = false;
        if(this.tag == "floor"||this.tag =="influ" || this.tag == "dissolve" || this.tag == "dissolveList")
        {
            string name = string.Format("{0}/{1}", sceneNum, FloorColor);
            this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));
        }
        source = gameObject.AddComponent<AudioSource>();

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
            if(Input .GetMouseButtonDown(0)&&this .tag !="influ" && this.tag != "contrast" && this.tag != "heart")
            {//左键将混合后的颜色加到主角身上
                    source.PlayOneShot(absorb, 1F);
                    characterColor.GetComponent<CharacterComponent>().CharacterColor = GameObject .Find ("EventSystem").GetComponent <AcquirAndShootColor >().ReturnColor(FloorColor, characterColor.GetComponent<CharacterComponent>().CharacterColor);

                    //instantiate particle
                    Instantiate(particleAbsorb, GameManager.Instance.line.GetComponent<DrawLine>().hitobject.transform.position, Quaternion.identity);
                    //particleAbsorb.transform.position = Vector2.MoveTowards(particleAbsorb.transform.position, new Vector2(0,0), pSpeed*Time.deltaTime);
                    //particleAbsorb.transform.position = new Vector3(Mathf.Lerp(particleAbsorb.transform.position.x, GameManager.Instance.line.GetComponent<DrawLine>().player.position.x, pSpeed * Time.deltaTime), Mathf.Lerp(particleAbsorb.transform.position.y, GameManager.Instance.line.GetComponent<DrawLine>().player.position.y, pSpeed * Time.deltaTime), 0);


                }
                else if(Input.GetMouseButtonDown(0) && this.tag == "contrast")
                {
                    source.PlayOneShot(absorb, 1F);
                    Instantiate(particleAbsorb, GameManager.Instance.line.GetComponent<DrawLine>().hitobject.transform.position, Quaternion.identity);
                    characterColor.GetComponent<CharacterComponent>().CharacterColor = GameObject.Find("EventSystem").GetComponent<AcquirAndShootColor>().ReturnContrastColor(characterColor.GetComponent<CharacterComponent>().CharacterColor);
                }
            if(Input.GetMouseButtonDown(1)&&this .tag !="status"&& characterColor.GetComponent<CharacterComponent>().CharacterColor!="transp" && this.tag != "contrast" && this.tag != "heart")
            {//右键将物体颜色染成主角的颜色
                    source.PlayOneShot(shoot, 1F);
                    FloorColor = characterColor.GetComponent<CharacterComponent>().CharacterColor;
                string name = string.Format("{0}/{1}", sceneNum, characterColor.GetComponent<CharacterComponent>().CharacterColor);
                this.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load(name, typeof(Sprite));

                    Instantiate(particleShoot, GameManager.Instance.line.GetComponent<DrawLine>().liziPos.position, Quaternion.identity);

                }
                else if(Input.GetMouseButtonDown(1) && this.tag == "heart"&& characterColor.GetComponent<CharacterComponent>().CharacterColor == "red"&&GameObject .Find ("EventSystem").GetComponent <AcquirAndShootColor >().isFinish ==true )
                {
                    source.PlayOneShot(shoot, 1F);
                    redHeart.SetActive(true);

                    //Color color=whiteheartRender.color;
                    //color.g = 0;
                    //color.b = 0;
                    //whiteheartRender.color=color;

                    Instantiate(particleShoot, GameManager.Instance.line.GetComponent<DrawLine>().liziPos.position, Quaternion.identity);
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
