using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicTrigger : MonoBehaviour
{
    AudioSource src;
    AudioClip clip;
    GameObject obj;
    int isPlaying;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("isPlaying", 0);
        obj = GameObject.Find("musicTrigger");
       
            src = GameObject.Find("musicTrigger").AddComponent<AudioSource>();
            src.playOnAwake = false;
            src.loop = true;
            clip = Resources.Load<AudioClip>("Sounds/boss_sound");
            src.clip = clip;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !src.isPlaying && PlayerPrefs.GetInt("isPlaying")==0)
        {
            StartCoroutine(playBossMusic());
        }
    }
    public IEnumerator playBossMusic()
    {
        PlayerPrefs.SetInt("isPlaying", 1);
        src.Play();
        src.volume = 0f;
        for (float i = 0f; i < 1f; i += 0.05f)
        {
            src.volume = i;
            yield return new WaitForSeconds(0.05f);
        }

    }

}
