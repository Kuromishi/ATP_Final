using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private LineRenderer linerenderer;
    [SerializeField] private Material material;
    [SerializeField] private Vector2 tiling;
    [SerializeField] private int mainTexProperty;
    [SerializeField] private Transform player;
    private float lineLen;
    [SerializeField] private float density = 2f;
    private Vector3 MousePosition;
    public bool isCollide;
    public GameObject hitobject;
    public float distance;
    private void Update()
    {
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //…‰œﬂºÏ≤‚
        var origin = player.position;
        var dir = Vector3.Normalize(MousePosition - player.position);
        //Debug.Log(MousePosition);
        //Debug.Log(dir);
        RaycastHit2D hit = Physics2D.Raycast(origin, dir,distance);
        //Debug.DrawRay(origin, dir);
        
        if(hit.collider != null)
        {
            //Debug.Log("is collide");
            //Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "floor"|| hit.collider.gameObject.tag == "status"|| hit.collider.gameObject.tag == "influ")
        {
            //Debug.Log("collide floor");
            isCollide = true;
            linerenderer.SetPosition(1, hit.point);
            hitobject = hit.collider.gameObject;

        }
        }
        
        else {
            //Debug.Log("dont collide");
            isCollide = false;
            linerenderer.SetPosition(1, MousePosition);
        }

        linerenderer.SetPosition(0, player.position);
        
        lineLen = Vector2 .Dot((linerenderer.GetPosition(1) - linerenderer.GetPosition(0)), (linerenderer.GetPosition(1) - linerenderer.GetPosition(0)));
        tiling = new Vector2(Mathf.Sqrt(lineLen) * density, 1);
        
        material.SetTextureScale(mainTexProperty, tiling);
    }

    private void Start()
    {
        material = linerenderer.material;
        mainTexProperty = Shader.PropertyToID("_MainTex");
        //tiling = new Vector2(38, 1);
        //material.SetTextureScale(mainTexProperty, tiling);

        
    }
}
