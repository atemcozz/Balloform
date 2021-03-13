using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    public bool isPressed = false;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "buttonBody")
        {
            isPressed = true;
            door.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "buttonBody")
        {
            isPressed = false;
            door.SetActive(true);
        }
    }
}
