using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeForce : MonoBehaviour
{
    HingeJoint2D joint;
    AudioSource src;
    AudioClip rip;
    AudioClip bridge;
    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.loop = false;
        joint = GetComponent<HingeJoint2D>();
        rip = Resources.Load<AudioClip>("Sounds/rip");
        bridge = Resources.Load<AudioClip>("Sounds/bridge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnJointBreak2D(Joint2D joint)
    {
        src.PlayOneShot(rip);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.GetComponent<Rigidbody2D>() != null) && (other.gameObject.GetComponent<Rigidbody2D>().mass >= 5) && (joint != null)) 
        { 
            
      
        
            joint.breakForce = 50f;
            
        
       }
        if ((other.gameObject.GetComponent<Rigidbody2D>() != null) && (other.gameObject.GetComponent<Rigidbody2D>().mass >= 1))
        {
            src.PlayOneShot(bridge);
        }
    }
}
