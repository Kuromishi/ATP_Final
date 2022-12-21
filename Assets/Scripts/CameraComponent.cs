using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    public Transform playerPos;
    public float smoothLerp;

    private void LateUpdate()
    {
        if(playerPos != null)
        {
            if(transform.position != playerPos.position)
            {
                Vector3 targetPos = playerPos.position;
                transform.position = Vector3.Lerp(transform.position, playerPos.position, smoothLerp);
            }
        }
    }
}
