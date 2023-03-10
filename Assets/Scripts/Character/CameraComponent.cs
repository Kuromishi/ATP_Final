using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public float XMargin;
    public float YMargin;
    public float XSmooth = 8.0f;
    public float YSmooth = 8.0f;

    public Transform Target;

    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - Target.position.x) > XMargin;
    }
    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - Target.position.y) > YMargin;
    }
    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        float targetX = transform.position.x;
        float targetY = transform.position.y;
        if (CheckXMargin())
        {
            targetX = Mathf.Lerp(transform.position.x, Target.position.x, XSmooth * Time.deltaTime);
        }
        if (CheckYMargin())
        {
            targetY = Mathf.Lerp(transform.position.y, Target.position.y, YSmooth * Time.deltaTime);
        }
       transform.position = new Vector3(targetX , targetY , transform.position.z);
    }
}
