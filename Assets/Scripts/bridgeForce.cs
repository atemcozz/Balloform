using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeForce : MonoBehaviour
{
    HingeJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.GetComponent<Rigidbody2D>() != null) && (other.gameObject.GetComponent<Rigidbody2D>().mass >= 5) && (joint != null)) 
        { 
            
        
        
            joint.breakForce = 50f;
        
       }
    }
}
