using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null) other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0.5f));
        
        if (other.gameObject.tag == "phObj") other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "phObj") other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "phObj") other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
