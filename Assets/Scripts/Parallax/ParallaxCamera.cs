using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovementX, float deltaMovementY);
 
    public ParallaxCameraDelegate onCameraTranslate;
   
    private float oldPositionX;
    private float oldPositionY;
    void Start()
    {
        oldPositionX = transform.position.x;
        oldPositionY = transform.position.y;
    }
    void FixedUpdate()
    {
        if (transform.position.x != oldPositionX)
        {
            if (onCameraTranslate != null)
            {
                float deltaX = oldPositionX - transform.position.x;
                onCameraTranslate(deltaX, 0f);
            }
            oldPositionX = transform.position.x;
        }
        if (transform.position.y != oldPositionY)
        {
            if (onCameraTranslate != null)
            {
               
                float deltaY = oldPositionY - transform.position.y;
                onCameraTranslate(0f, deltaY);
            }
            oldPositionY = transform.position.y;
        }
    }
}
