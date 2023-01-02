using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOveShoot : MonoBehaviour
{
    public float pSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameManager.Instance.line.GetComponent<DrawLine>().hitobject.transform.position, pSpeed * Time.deltaTime);
        Destroy(gameObject, 0.4f);
    }
}
