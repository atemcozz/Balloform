using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class manager2 : MonoBehaviour
{
    [HideInInspector] public int number;
    storage st;
    public event UnityAction<int> LoadScreen;
    public GameObject menuObj, partObj,levelObj,aboutObj;
    AudioSource src;
    AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        
        AudioListener.volume = storage.data.volume;
        number = storage.data.currentLevel;
        src = gameObject.AddComponent<AudioSource>();
        sound = Resources.Load<AudioClip>("Sounds/ui");
        //LoadScreen += GetComponent<levelChange>().previewChange;
        if (PlayerPrefs.HasKey("menu"))
        {
            OnPartButtonClick();
            LoadScreen?.Invoke(number);
            PlayerPrefs.DeleteAll();
        }

      //  PlayGamesPlatform.DebugLogEnabled = true;
      //  PlayGamesPlatform.Activate();

      
        // Social.localUser.Authenticate(success =>
        // {
        //     if (success)
        //     {
        //         Debug.Log("sauth");

        //     }
        //     else
        //     {

        //     }
        // });
        // if (!PlayGamesPlatform.Instance.HasPermission("email"))
        // {
        //     PlayGamesPlatform.Instance.RequestPermission("email", result => {
        //         // handle results
        //     });
        // }
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
        if(number!=0)SceneManager.LoadScene("level_" + number);
        else SceneManager.LoadScene("tutorial");
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
      //  PlayGamesPlatform.Instance.SignOut();
        Application.Quit();
    }
    public void OnPartButtonClick()
    {
        PlayClickSound();
        if(number != storage.data.maxLevel) LoadScreen?.Invoke(number);
        else LoadScreen?.Invoke(--number);
        menuObj.SetActive(false);
        partObj.SetActive(false);
        levelObj.SetActive(true);

    }
    public void OnArrowClick(Button button)
    {
        if (button.gameObject.name == "rightButton" && number < storage.data.maxLevel-1)
        {
            number++;
            LoadScreen?.Invoke(number);
           
        }
        if(button.gameObject.name == "leftButton" && number > 0)
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
   
    void PlayClickSound()
    {
        
        src.PlayOneShot(sound);
    }
}
