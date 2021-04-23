using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsToggle : MonoBehaviour
{
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        if (storage.data.fpsShow == true) toggle.isOn = true;
        else toggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStateChanged()
    {
        if (toggle.isOn) storage.data.fpsShow = true;
        else storage.data.fpsShow = false;
        storage.SaveRecord();
    }
}
