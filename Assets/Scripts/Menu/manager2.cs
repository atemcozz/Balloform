using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class manager2 : MonoBehaviour
{
    [HideInInspector] public int number = storage.data.currentLevel;
    storage st;
    public event UnityAction<int> LoadScreen;
    public GameObject menuObj, partObj,levelObj,aboutObj;
    AudioSource src;
    AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        sound = Resources.Load<AudioClip>("Sounds/ui");
        //LoadScreen += GetComponent<levelChange>().previewChange;
        if (PlayerPrefs.HasKey("menu"))
        {
            OnPartButtonClick();
            LoadScreen?.Invoke(number);
        }
    }
    public void OnPlayButtonClick()
    {
        menuObj.SetActive(false);
        partObj.SetActive(true);
        PlayClickSound();
    }
    public void OnGamePlayButtonClick()
    {
        PlayClickSound();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("level_" + number);
    }
    public void OnAboutButtonClick()
    {
        menuObj.SetActive(false);
        aboutObj.SetActive(true);
        PlayClickSound();
    }
    public void OnExitButtonClick()
    {
        
        PlayClickSound();
        Application.Quit();
    }
    public void OnPartButtonClick()
    {
        PlayClickSound();
        LoadScreen?.Invoke(number);
        partObj.SetActive(false);
        levelObj.SetActive(true);

    }
    public void OnArrowClick(Button button)
    {
        if (button.gameObject.name == "rightButton")
        {
            number++;
            LoadScreen?.Invoke(number);
           
        }
        else if(number > 0)
        {
            number--;
            LoadScreen?.Invoke(number);
        }
        PlayClickSound();
    }
  
    public void OnReturnButtonClick()
    {
      if(levelObj.activeSelf == true)
        {
            levelObj.SetActive(false);
            partObj.SetActive(true);
        }
        else {
            menuObj.SetActive(true);
            aboutObj.SetActive(false);
            partObj.SetActive(false);
        }
        PlayClickSound();
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    void PlayClickSound()
    {
        
        src.PlayOneShot(sound,storage.data.volume);
    }
}
