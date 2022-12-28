using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItself : MonoBehaviour
{
    public float speed = 80f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-Vector3.forward * Time.deltaTime * speed);
    }
}
