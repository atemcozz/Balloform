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
    Text gameVersion;


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
