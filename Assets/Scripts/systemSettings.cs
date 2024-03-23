using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using System.IO;
public class systemSettings : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    Text ScoreText;
    Ball  ball;
    public Text resumeText, restartText, exitText,pauseTitle;
    AudioSource src;
    AudioClip ui;
    storage st;

    //public Ball src, loopsrc;
  

    // Start is called before the first frame update
    void Start()
    {
        
        src = gameObject.AddComponent<AudioSource>();
        ui = Resources.Load<AudioClip>("Sounds/ui");
       
        
        AudioListener.volume = storage.data.volume;
      
        
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
         ball = GameObject.Find("ball_def").GetComponent<Ball>();
 
        Application.targetFrameRate = 300;
       

        if(storage.data.eng == false)
        {
            resumeText.text = "Продолжить";
            restartText.text = "Начать \n заново";
            exitText.text = "В главное \n меню";
            pauseTitle.text = "Пауза";
        }
        else
        {
            resumeText.text = "Resume";
            restartText.text = "Restart";
            exitText.text = "Go to the \n main menu";
            pauseTitle.text = "Pause";
        }
    }



 
    // Update is called once per frame
    void Update() 
    {   
        ScoreText.text = ball.score.ToString();

        if(Input.GetKeyDown(KeyCode.Escape)){
            
                OnPauseButtonClick();
            
        }
    }
    
    public void OnExitButtonClick()
    {
        
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("menu", 1);
        AudioListener.volume = storage.data.volume;
        src.PlayOneShot(ui);
        SceneManager.LoadScene("Menu");
        
    }
    public void OnPauseButtonClick()
    {

        src.PlayOneShot(ui);
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        AudioListener.volume = 0f;

    }
    public void OnResumeButtonClick()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false); 
        pauseButton.SetActive(true);
        AudioListener.volume = storage.data.volume;

        src.PlayOneShot(ui);
    }
    public void OnRestartButtonClick()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        AudioListener.volume = storage.data.volume;
        src.PlayOneShot(ui);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
