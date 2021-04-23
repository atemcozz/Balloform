using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class progressText : MonoBehaviour
{
    float progress;
    // Start is called before the first frame update
    void Start()
    {
        progress = (float)Math.Round(storage.data.currentLevel * 100.0 / storage.data.maxLevel, 1);
        if(storage.data.eng == true) GetComponent<Text>().text = "Completed: "+progress.ToString() + "%";
        else GetComponent<Text>().text = "Пройдено: " + progress.ToString() + "%";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
