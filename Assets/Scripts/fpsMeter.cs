using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsMeter : MonoBehaviour
{

    public static float fps;
    private Text myText;
    private float _t = 0;
    void Start()
    {
        myText = GameObject.Find("FPSText").GetComponent<Text>();
    }
    

    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        if (_t < Time.time)
        {
            _t = Time.time + 1;
            myText.text = "FPS: " + (int)fps;
            //Debug.Log(fps);
        }
        
        
    }
   

}
