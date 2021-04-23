using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    //RectTransform rect;
    public float speed;
    public float startX;
    public float endX;
    public bool isLower;
    public Sprite[] backround0, backround1, backround2, backround3;
    public changeBackground parent;
   
   
    // Start is called before the first frame update
    void Start()
    {
        // rect = GetComponent<RectTransform>();

        switch (parent.type)
        {
            case 0:
                if (isLower == true) GetComponent<SpriteRenderer>().sprite = backround0[0];
                else GetComponent<SpriteRenderer>().sprite = backround0[1];
                break;

            case 1:
                if (isLower == true) GetComponent<SpriteRenderer>().sprite = backround1[0];
                else GetComponent<SpriteRenderer>().sprite = backround1[1];
                break;
            case 2:
                if (isLower == true) GetComponent<SpriteRenderer>().sprite = backround2[0];
                else GetComponent<SpriteRenderer>().sprite = backround2[1];
                break;
            case 3:
                if (isLower == true) GetComponent<SpriteRenderer>().sprite = backround3[0];
                else GetComponent<SpriteRenderer>().sprite = backround3[1];
                break;



        }
        Debug.Log(parent.type);
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

