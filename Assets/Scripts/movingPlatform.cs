using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour
{
    public float Xspeed = 50f;
    private float leftBorder;
    private float rightBorder;
    private int movingRight = 1;
    private int movingUp = 1;
    private float upBorder;
    private float downBorder;
    public float radius = 5;
    public float Yspeed = 50f;
    private Rigidbody2D rb;
    public bool isInverted = false;
    // Start is called before the first frame update
    void Start()
    {
        leftBorder = transform.position.x - radius; 
        rightBorder = transform.position.x + radius;
        downBorder = transform.position.y - radius;
        upBorder = transform.position.y + radius;

        rb = GetComponent<Rigidbody2D>();
        if(isInverted){
            movingRight = -movingRight;
            movingUp = -movingUp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightBorder)
        {
            movingRight = -1;
        }
        if (transform.position.x < leftBorder)
        {
            movingRight = 1;
        }
        if (transform.position.y > upBorder)
        {
            movingUp = -1;
        }
        if (transform.position.y < downBorder)
        {
            movingUp = 1;
        }
        //rb.AddForce(new Vector2(speed * movingRight * Time.deltaTime, 0));
        transform.position = new Vector2(transform.position.x + Xspeed * movingRight * Time.deltaTime, transform.position.y + Yspeed * movingUp * Time.deltaTime);
    }
}
