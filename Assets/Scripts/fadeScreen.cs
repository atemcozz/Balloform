using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeScreen : MonoBehaviour
{
    // Start is called before the first frame update
   public Image image;
  
    void Start()
    {
        Color color = image.color;
        color.a = 0f;
        image.color = color;
     

    }
    IEnumerator Fade()
    {
        for(float f = 0f; f<= 1f; f += 0.05f)
        {
            Color color = image.color;
            color.a = f;
            image.color = color;
            Debug.Log(f);
            yield return new WaitForSeconds(0.05f);

        }
        SceneManager.LoadScene("levelSelect");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            StartCoroutine("Fade");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
