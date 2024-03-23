using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsMeter : MonoBehaviour
{

    public static float fps;
    private Text myText;
    private float _t = 0;
    storage st;
    void Start()
    {
        myText = GameObject.Find("FPSText").GetComponent<Text>();
        st = gameObject.AddComponent<storage>();
        if(storage.data.fpsShow == false) myText.text = null;

        
    }
    

    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        if (_t < Time.time && storage.data.fpsShow == true)
        {
            _t = Time.time + 1;
            myText.text = "FPS: " + (int)fps;
            //Debug.Log(fps);
        }
        
        
    }
   

}
