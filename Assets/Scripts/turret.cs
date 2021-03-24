using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform ball;
    Vector2 direction;
    float offset = 2f;
    public float range = 1f;
    GameObject bullet,bullet_2;
    Transform shotPoint;
    public RaycastHit2D rayInfo;
    public float startShotTime;
    float ShotTime;
   public LayerMask ignoreRaycast;
    AudioSource src;
    AudioClip shot;
   public enum TurretType
    {
        normal = 0,
        speedy = 1,
    }
    [Header("Тип турели")]
    public TurretType type;
    [Header("Разброс пули в градусах")]
    public float Spread = 0f;
   
    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("bullet");
        bullet_2 = Resources.Load<GameObject>("bullet_2");
        shotPoint = transform.GetChild(0);
        ball = GameObject.Find("ball_def").transform;
        src = gameObject.AddComponent<AudioSource>();
        shot = Resources.Load<AudioClip>("Sounds/turretShot");
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 ballPos = ball.position;
        direction = ballPos - (Vector2)transform.position;
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
       
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
       
      
        rayInfo = Physics2D.Raycast(shotPoint.position, direction, range, ~ignoreRaycast);
        
       
        if (rayInfo == true && rayInfo.collider.transform == ball)
        {
            if (ShotTime <= 0)
            {
                
                if(type == 0) Instantiate(bullet, shotPoint.position, Quaternion.Euler(0f, 0f, rotZ - 90 + Random.Range(0-Spread,0+Spread)));
                else Instantiate(bullet_2, shotPoint.position, Quaternion.Euler(0f, 0f, rotZ - 90 + Random.Range(0 - Spread, 0 + Spread)));
                src.PlayOneShot(shot);
                ShotTime = startShotTime;
            }
            else ShotTime -= Time.deltaTime;
            

        }

    }
   
        
    
    
}
