using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public bool isSame = true;
    private void Start()
    {
        if (isSame == true) parallaxFactorY = parallaxFactorX;

    }
    public float parallaxFactorX;
    public float parallaxFactorY;
    public void Move(float deltaX, float deltaY)
    {
        Vector3 newPos = transform.localPosition;

        newPos.x -= deltaX * parallaxFactorX;
        newPos.y -= deltaY * parallaxFactorY;

        transform.localPosition = newPos;
    }
}