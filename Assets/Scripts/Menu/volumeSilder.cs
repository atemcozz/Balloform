using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeSilder : MonoBehaviour
{
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = storage.data.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnValueChanged()
    {
        storage.data.volume = slider.value;
        AudioListener.volume = slider.value;
        storage.SaveRecord();
    }
}
