using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 10;
    public int type = 0;
    GameObject particle;
    GameObject particle_speedy;
    [Header("Bullet lifetime in seconds")]
   public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        particle = Resources.Load<GameObject>("particle_bullet");
        particle_speedy = Resources.Load<GameObject>("particle_bullet_speedy");
        StartCoroutine(destroyBullet());
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer != 11)
        {
            if (type == 0) Instantiate(particle, transform.position, transform.rotation);
            else Instantiate(particle_speedy, transform.position, transform.rotation);
            Destroy(gameObject);
        }

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
