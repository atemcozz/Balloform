using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class tutorialScreen : MonoBehaviour
{
    Sprite[] russprites, engsprites;
    public int selLevel = 0;
    public Image image;
    AudioSource src;
    AudioClip ui;
   
    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        ui = Resources.Load<AudioClip>("Sounds/ui");
        russprites = Resources.LoadAll<Sprite>("tutorial/rus");
        engsprites = Resources.LoadAll<Sprite>("tutorial/eng");
        if (storage.data.eng == false) image.sprite = russprites[selLevel];
        else image.sprite = engsprites[selLevel];

        AudioListener.volume = storage.data.volume;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNextButtonDown()
    {
        src.PlayOneShot(ui);
        if (selLevel < 7)
        {
            selLevel++;
            if (storage.data.eng == false) image.sprite = russprites[selLevel];
            else image.sprite = engsprites[selLevel];
        }
        else
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("level_0");
        }
    }
    public void OnLastButtonDown()
    {
        src.PlayOneShot(ui);
        
      
        if (selLevel > 0)
        {
            selLevel--;
            if (storage.data.eng == false) image.sprite = russprites[selLevel];
            else image.sprite = engsprites[selLevel];
        }
        else
        {
            PlayerPrefs.SetInt("menu", 1);
            SceneManager.LoadScene("Menu");
        }


        
    }
}
