using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bonus : MonoBehaviour
{
    GameObject rb;
    Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {

        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
        rb = GameObject.Find("ball_def");
        if(PlayerPrefs.HasKey(gameObject.name)){
        gameObject.SetActive(false);
}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.tag == "Player" && !PlayerPrefs.HasKey(gameObject.name)){

      PlayerPrefs.SetInt(gameObject.name, 1);


       StartCoroutine(Collect());




       
       }
 IEnumerator Collect()
    {

        for (float f = 195f/255f; f > 0f; f -= 0.1f)
        {
           Color color = GetComponent<SpriteRenderer>().color;
            color.a = f;
            GetComponent<SpriteRenderer>().color = color;
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = color;
           
            yield return new WaitForSeconds(0.01f);

        }
    gameObject.SetActive(false);
}



}


}
