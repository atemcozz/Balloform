using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonCheck : MonoBehaviour
{
    AudioSource src;
    AudioClip buttonHit;
    public bool isPressed = false;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.loop = false;
        buttonHit = Resources.Load<AudioClip>("Sounds/buttonHit");
        src.spatialBlend = 1f;
        src.rolloffMode = AudioRolloffMode.Linear;
        src.minDistance = 20f;
        src.maxDistance = 50f;
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
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null) src.PlayOneShot(buttonHit, 0.5f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "buttonBody")
        {
            isPressed = false;
            door.SetActive(true);
            if (collision.gameObject.GetComponent<Rigidbody2D>() != null) src.PlayOneShot(buttonHit, 0.5f);

        }
    }
}
