using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    //RectTransform rect;
    public float speed;
    public float startX;
    public float endX;
  
   
   
    // Start is called before the first frame update
    void Start()
    {
       // rect = GetComponent<RectTransform>();
        
     
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        transform.Translate(Vector2.left * speed);
        if (transform.position.x <= endX)
        {
            transform.position = new Vector2(startX, transform.position.y);
        }

      
    }
}

