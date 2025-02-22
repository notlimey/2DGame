﻿using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    public float Smoothing;
    
    public void LateUpdate()
    {
        if (transform.position != Target.position)
        {
            Vector3 targetPosition = new Vector3(Target.position.x,
                                                    Target.position.y,
                                                    transform.position.z);
            transform.position = Vector3.Lerp(transform.position,
                                                targetPosition, Smoothing);
        }
    }
}
