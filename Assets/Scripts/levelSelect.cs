using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{

    public PermanentSave ps = new PermanentSave();
    public  string[] levelDescText = { "������������ � �������� ���������� ����", "������ ����", "������"};
    [SerializeField]
    GameObject preview;
    [SerializeField]
    GameObject underText;
    [SerializeField]
    GameObject labelT;
    public GameObject MainMenu;
    public GameObject About;
    public GameObject LevelSelect;
    public InputField field;
    public Text currentScore;
    public Text bestScore;
    public Text currentResult;
    public Color activePlay;
    public Color unactivePlay;
    public GameObject playButton;
     public GameObject playButtonBlank;
    SaveRecords sr = new SaveRecords();
    public class SaveRecords
    {

        public List<float> records = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public List<float> current = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    }



    public Sprite[] prsprites;

    //Sprite[] prviews = Resources.LoadAll("Sprites/levelPreviews");

    [Serializable]
    public class PermanentSave
    {
        public int levelProgress = 0;
        public int selLevel = 0;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
        if(File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        ps.selLevel = ps.levelProgress;
        preview.GetComponent<Image>().sprite = prsprites[ps.selLevel + 1];
        underText.GetComponent<Text>().text = levelDescText[ps.selLevel];
        labelT.GetComponent<Text>().text = ("Уровень " + ps.selLevel);
        if (PlayerPrefs.HasKey("menu"))
        {
            OnPlayButtonClick();
            PlayerPrefs.DeleteKey("menu");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnLeftButtonClick()
    {
        if (ps.selLevel > 0) ps.selLevel--;
       
        Debug.Log(ps.selLevel);
    }
    public void OnRightButtonClick()
    {
        ps.selLevel++;

        Debug.Log(ps.selLevel);
    }
    public void OnPreviewClick()
    {
       if(ps.selLevel <= ps.levelProgress)
        {
           
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("level_" + ps.selLevel);
        }
    }
    public void OnPlayButtonClick()
    {
        MainMenu.SetActive(false);
        LevelSelect.SetActive(true);
        //SceneManager.LoadScene("levelSelect");
       bestScore = GameObject.Find("bestScore").GetComponent<Text>();
        currentScore = GameObject.Find("currentScore").GetComponent<Text>();
        currentResult = GameObject.Find("currentResult").GetComponent<Text>();
        playButton = GameObject.Find("playButton");
        playButtonBlank = GameObject.Find("playButtonBlank");
currentScore.text = sr.current[ps.selLevel].ToString();
        bestScore.text = sr.records[ps.selLevel].ToString();
         playButton.GetComponent<Image>().color = new Color(0f,200f/255f,60f/255f);
        if(sr.current[ps.selLevel] == sr.records[ps.selLevel] && sr.current[ps.selLevel] != 0) {
            currentResult.text = "Новый рекорд!";

            currentResult.color = new Color(0f,200f/255f,60f/255f);
        }
        else {
            currentResult.text = "Текущий результат:";
            currentResult.color = new Color(50f/255f,50f/255f,50f/255f);
        }
        
    }
    public void OnReturnButtonClick()
    {
        LevelSelect.SetActive(false);
        About.SetActive(false);
        MainMenu.SetActive(true);
        
        //SceneManager.LoadScene("Menu");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public void OnAboutButtonClick()
    {
       
        About.SetActive(true);
        MainMenu.SetActive(false);

        //SceneManager.LoadScene("About");
    }
    public void OnLoRButtonClick()
    {
        if (ps.selLevel > ps.levelProgress)
        {

            preview.GetComponent<Image>().sprite = prsprites[0];
            underText.GetComponent<Text>().text = "Уровень в разработке";
            currentScore.text = "-";
            bestScore.text = "-";
            //playButton.SetActive(false);
            playButton.GetComponent<Image>().color = new Color(128f/255f,128f/255f,128f/255f);
            
            currentResult.text = "Текущий результат:";
            currentResult.color = new Color(50f/255f,50f/255f,50f/255f);
            playButtonBlank.SetActive(false);
        }
        else
        {
            preview.GetComponent<Image>().sprite = prsprites[ps.selLevel + 1];
          
            underText.GetComponent<Text>().text = levelDescText[ps.selLevel];

            if(sr.current[ps.selLevel] == sr.records[ps.selLevel] && sr.current[ps.selLevel] != 0) {
                currentResult.text = "Новый рекорд!";

                currentResult.color = new Color(0f,200f/255f,60f/255f);
            }
            else {
                currentResult.text = "Текущий результат:";
                currentResult.color = new Color(50f/255f,50f/255f,50f/255f);
            }
            currentScore.text = sr.current[ps.selLevel].ToString();
            bestScore.text = sr.records[ps.selLevel].ToString();
            playButtonBlank.SetActive(true);
            //playButton.SetActive(true);
 playButton.GetComponent<Image>().color = new Color(0f,200f/255f,60f/255f);
        }
        if(ps.selLevel != 0) 
        { 
          labelT.GetComponent<Text>().text = ("Уровень " + ps.selLevel);
        }
        else
        {
            labelT.GetComponent<Text>().text = ("Обучение");
        }


    }


    public void OnBonusButtonDown(){
       if(field.text == "debug"){
           PlayerPrefs.DeleteAll();
           SceneManager.LoadScene("level_debug");
       }
       if(field.text == "pain"){
           PlayerPrefs.DeleteAll();
           SceneManager.LoadScene("bonus_1");
       }

    }
}
