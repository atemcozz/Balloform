using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterController : MonoBehaviour
{
    //public Rigidbody2D rb;
    public bool isSticky = false;
  public Ball ball;
  public float elevatorSpeed = 20f;
  public float boosterSpeed = 100f;
    AudioSource src;
    AudioClip booster;
    public int col;
    // Start is called before the first frame update
    void Start()
    {
      booster = Resources.Load<AudioClip>("Sounds/booster");
      src = gameObject.AddComponent<AudioSource>();
        src.loop = true;
        src.clip = booster;
        src.spatialBlend = 1f;
        src.rolloffMode = AudioRolloffMode.Linear;
        src.minDistance = 20f;
        src.maxDistance = 50f;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            
            
            if (gameObject.tag == "booster_left")
            {
                if (ball.save.ballState != 0)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-boosterSpeed, 0f));
                }
                else
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-boosterSpeed/10, 0f));
                }
            }

            if (gameObject.tag == "booster_right")
            {

                if (ball.save.ballState != 0)
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(boosterSpeed, 0f));
                }
                else
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(boosterSpeed/10, 0f));
                }
            }
            if (gameObject.tag == "elevator")
            {
                if (ball.save.ballState != 0)
                {
                   // ball.rb.AddForce(new Vector2(0f, elevatorSpeed));
                   other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, elevatorSpeed));
                }
                else
                {
                    other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, elevatorSpeed/10));

                }


            }
        }

        
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.GetComponent<Rigidbody2D>() != null) && isSticky == false  && other.gameObject.layer != 11)
        {
                 col++;
                if (!src.isPlaying) src.Play();
            
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (isSticky == false && src.isPlaying && other.gameObject.layer != 11)
        {
            col--;
            if(col == 0) src.Stop();
            
        }
    }
}
