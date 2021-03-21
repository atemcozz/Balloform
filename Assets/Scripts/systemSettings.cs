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
    Text ScoreText, gameVersion;
    Ball  ball;
    public Text resumeText, restartText, exitText,pauseTitle;
    AudioSource src;
    AudioClip ui;


    //public Ball src, loopsrc;

    public class SaveRecords
    {

        public List<float> records = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public List<float> current = new List<float>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public bool eng = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        src = gameObject.AddComponent<AudioSource>();
        ui = Resources.Load<AudioClip>("Sounds/ui");
        SaveRecords sr = new SaveRecords();
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }

        gameVersion = GameObject.Find("(R)").GetComponent<Text>();
        gameVersion.text = ("v"+ Application.version + "_alpha");
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
         ball = GameObject.Find("ball_def").GetComponent<Ball>();
 
        Application.targetFrameRate = 300;
        AudioListener.volume = 1f;

        if(sr.eng == false)
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
        AudioListener.volume = 1f;
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
        AudioListener.volume = 1f;
       
        src.PlayOneShot(ui);
    }
    public void OnRestartButtonClick()
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        AudioListener.volume = 1f;
        src.PlayOneShot(ui);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
