using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spPaperBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "water")
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.5f));
        }
    }
}
