using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class commonBalls : MonoBehaviour
{
    Rigidbody2D rb;
    AudioClip hit;
    AudioClip normalLoop;
    AudioClip stoneLoop;
    AudioClip paperLoop;
    AudioClip paperHit;
    AudioClip waterInto;
    AudioClip waterOut;
    AudioSource src;
    AudioSource loopsrc;
    bool isPaper;
    public bool isGround;
    public float checkRadius = 0.3f;
    LayerMask whatIsGround;
    GameObject groundCheck;
    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        loopsrc = gameObject.AddComponent<AudioSource>();
        //3d-audio
        src.spatialBlend = 1f;
        src.rolloffMode = AudioRolloffMode.Linear;
        src.minDistance = 20f;
        src.maxDistance = 50f;

        loopsrc.spatialBlend = 1f;
        loopsrc.rolloffMode = AudioRolloffMode.Linear;
        loopsrc.minDistance = 20f;
        loopsrc.maxDistance = 50f;

        groundCheck = Resources.Load<GameObject>("groundCheck");
        rb = GetComponent<Rigidbody2D>();
        hit = Resources.Load<AudioClip>("Sounds/hit");
        normalLoop = Resources.Load<AudioClip>("Sounds/normalLoop");
        waterInto = Resources.Load<AudioClip>("Sounds/water-into");
        waterOut = Resources.Load<AudioClip>("Sounds/water-out");
        stoneLoop = Resources.Load<AudioClip>("Sounds/stoneLoop");
        paperLoop = Resources.Load<AudioClip>("Sounds/paperLoop");
        paperHit = Resources.Load<AudioClip>("Sounds/paperHit");
        
        loopsrc.loop = true;
        loopsrc.playOnAwake = false;
        if (rb.mass < 1f) isPaper = true;
        else isPaper = false;
        

        switch (rb.mass)
        {
            case 0.05f:
                loopsrc.clip = paperLoop;
                break;
            case 1f:
                loopsrc.clip = normalLoop;
                break;
            case 5f:
                loopsrc.clip = stoneLoop;
                break;
        }
        groundCheck = Instantiate(groundCheck, transform);
        whatIsGround = LayerMask.GetMask("Ground","Boxes");
    }

    public void OnCollisionEnter2D(Collision2D other)
    {

       if((rb.velocity.magnitude > 2) && (rb.mass >= 1f)) src.PlayOneShot(hit, rb.velocity.magnitude / 5);
       else if(isPaper) src.PlayOneShot(paperHit, rb.velocity.magnitude / 5);

        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        {
           
            if (!isPaper) src.PlayOneShot(waterInto, rb.velocity.magnitude / 10);
            else src.PlayOneShot(waterOut, rb.velocity.magnitude / 10);
        }

        
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 8) src.PlayOneShot(waterOut, rb.velocity.magnitude / 10);
    }
    // Update is called once per frame
    void Update()
    {
        checkGround();
        loopsrc.pitch = rb.velocity.x / 7;
        groundCheck.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y - (GetComponent<CircleCollider2D>().bounds.size.y / 2));
        if (!loopsrc.isPlaying && isGround)
        {
            loopsrc.Play();
        }
        if (loopsrc.isPlaying && !isGround)
        {
            loopsrc.Stop();
        }
    }
    void checkGround()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, whatIsGround);
       
    }
}
