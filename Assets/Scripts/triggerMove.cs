using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerMove : MonoBehaviour
{
    public Transform obj; //Object to move
    public enum Modes
    {
        vertical = 0,
        horizontal = 1,
    }
    public Modes mode;
    AudioSource src;
    AudioClip bossMusic;
    int isMoving;
    public float distance;
    float border;
    public float speed = 3;
    // Start is called before the first frame update
    void Start()
    {
        if (mode == 0) border = obj.transform.position.y + distance;
        else border = obj.transform.position.x + distance;
        src = gameObject.AddComponent<AudioSource>();
        src.playOnAwake = false;
        src.loop = true;
        bossMusic = Resources.Load<AudioClip>("Sounds/boss_sound");
        src.clip = bossMusic;
    }

    // Update is called once per frame
    void Update()
    {
        if ((obj.transform.position.y >= border && mode == 0) || (obj.transform.position.x >= border && mode != 0))
        {
            isMoving = 0;
        }
        if(mode == 0) obj.transform.position = new Vector2(obj.transform.position.x, obj.transform.position.y + speed * isMoving * Time.deltaTime);
        else obj.transform.position = new Vector2(obj.transform.position.x + speed * isMoving * Time.deltaTime, obj.transform.position.y );
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            isMoving = 1;
            StartCoroutine(playBossMusic());
        }
    }
   IEnumerator playBossMusic()
    {
        src.Play();
        src.volume = 0f;
        for(float i = 0f; i<1f; i += 0.05f)
        {
            src.volume = i;
            yield return new WaitForSeconds(0.05f);
        }
        
    }
}
