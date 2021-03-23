using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform ball;
    Vector2 direction;
    public float offset = 0f;
    public float range = 1f;
    GameObject bullet;
    Transform shotPoint;
    public RaycastHit2D rayInfo;
    public float startShotTime;
    float ShotTime;
   public LayerMask ignoreRaycast;
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("bullet");
        shotPoint = transform.GetChild(0);
        ignoreRaycast = LayerMask.NameToLayer("ignoreRaycast");
        ball = GameObject.Find("ball_def").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 ballPos = ball.position;
        direction = ballPos - (Vector2)transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
       
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
       
      
        rayInfo = Physics2D.Raycast(shotPoint.position, direction, range,  ignoreRaycast);
        Debug.DrawLine(transform.position, direction);

        if (rayInfo == true && rayInfo.collider.transform == ball)
        {
            if (ShotTime <= 0)
            {
                Instantiate(bullet, shotPoint.position, Quaternion.Euler(0f, 0f, rotZ - 90));
                ShotTime = startShotTime;
            }
            else ShotTime -= Time.deltaTime;
            

        }

    }
   
        
    
    
}
