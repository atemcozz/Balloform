using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    float speed = 10;
  
    [AddComponentMenu("Bullet lifetime in seconds")]
   public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(destroyBullet());
        
    }
    public void OnCollisionEnter2D(Collision2D col)
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