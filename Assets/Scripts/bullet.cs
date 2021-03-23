using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float speed = 10;
    Rigidbody2D rb;
    [AddComponentMenu("Bullet lifetime in seconds")]
   public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet());
        rb = GetComponent<Rigidbody2D>();
    }
    void OnCollisionEnter2D()
    { 
       Destroy(gameObject);
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
        
    }
    IEnumerator destroyBullet()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
   
}
