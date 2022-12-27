using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BecomeFloor : MonoBehaviour
{
    public Material mat;
    //放在场景中的物体而不是prefab上
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent <MouseFloatAndDrawLine >().FloorColor.Equals ( this.GetComponent<MouseFloatAndDrawLine>().correctColor))
        {
            
            StartCoroutine(StartDesolve());
        }
    }

    IEnumerator StartDesolve()
    {
        float duration = 0; 
        this.GetComponent<SpriteRenderer>().material = mat;
        this.GetComponent<SpriteRenderer>().material.SetFloat("_DissolveThreshold", 0.0f);
        yield return null;
        while (true)
        {
            duration += Time.deltaTime;
            if(duration > 1.0f)
            {
                Destroy(gameObject);
                break;
            }
            float t_val =  duration;
            this.GetComponent<SpriteRenderer>().material.SetFloat("_DissolveThreshold", t_val);
            yield return null;
        }
    }
}
