using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMove : MonoBehaviour
{
    public Transform obj;
    int isMoving;
    public float distance;
    float border;
    public float speed = 3;
   // Start is called before the first frame update
    void Start()
    {
        border = obj.transform.position.y + distance;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(obj.transform.position.y >= border){
            isMoving = 0;
        }
        obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + speed * isMoving * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isMoving = 1;
        }
    }
}
