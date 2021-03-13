using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class systemSettings : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    Text ScoreText;
    Ball  ball;

    
    //public Ball src, loopsrc;



    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
         ball = GameObject.Find("ball_def").GetComponent<Ball>();
 
        Application.targetFrameRate = 300;
        AudioListener.volume = 1f;


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
        SceneManager.LoadScene("Menu");
    }
    public void OnPauseButtonClick()
    {
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
        AudioListener.volume = 1f;
    }
    public void OnRestartButtonClick()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
