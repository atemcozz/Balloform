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
    public string[] englevelDescText;
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
    AudioSource src;
    AudioClip ui;

    public Text playText, aboutText, exitText, currentScore, bestScore, currentResult,bestResultLabel, levelSelPlayButtonLabel, description, bonusCode;
    string level;
    

    public Color activePlay;
    public Color unactivePlay;
    public GameObject playButton;
     public GameObject playButtonBlank;
    SaveRecords sr = new SaveRecords();
    public class SaveRecords
    {

        public List<float> records = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public List<float> current = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public bool eng = true;
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
        src = gameObject.AddComponent<AudioSource>();
        ui = Resources.Load<AudioClip>("Sounds/ui");
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        if (sr.eng == true)
        {
            playText.text = "Play";
            aboutText.text = "About";
            exitText.text = "Exit";
            level = "Level ";
            bonusCode.text = "Bonus code:";
            bestResultLabel.text = "Best result:";
            levelSelPlayButtonLabel.text = "Play";
            description.text = "Balloform is a minimalist puzzle game that inherits and brings together the elements of cult games like Ballance and Bounce, while maintaining its unique style";
            
        }
        else
        {
            playText.text = "Играть";
            aboutText.text = "Об игре";
            exitText.text = "Выйти";
            level = "Уровень ";
            bonusCode.text = "Бонусный код:";
            bestResultLabel.text = "Лучший результат:";
            levelSelPlayButtonLabel.text = "Играть";
            description.text = "Balloform  -  игра-головоломка в минималистичном стиле, которая унаследовала и собрала воедино элементы таких культовых игр, как Ballance и Bounce, но в тоже время смогла сохранить свой уникальный стиль";
        }
        
        ps.selLevel = ps.levelProgress;
        preview.GetComponent<Image>().sprite = prsprites[ps.selLevel + 1];

       if(sr.eng == false) underText.GetComponent<Text>().text = levelDescText[ps.selLevel];
       else underText.GetComponent<Text>().text = englevelDescText[ps.selLevel];
        labelT.GetComponent<Text>().text = (level + ps.selLevel);
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
       if(ps.selLevel <= ps.levelProgress && ps.selLevel != 0)
        {
            src.PlayOneShot(ui);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("level_" + ps.selLevel);
        }
       else if(ps.selLevel == 0) SceneManager.LoadScene("tutorial");

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
        if(!PlayerPrefs.HasKey("menu")) src.PlayOneShot(ui);
        playButton.GetComponent<Image>().color = new Color(0f,200f/255f,60f/255f);
        if(sr.current[ps.selLevel] == sr.records[ps.selLevel] && sr.current[ps.selLevel] != 0) {

          if(sr.eng == false)  currentResult.text = "Новый рекорд!";
          else currentResult.text = "New Record!";

            currentResult.color = new Color(0f,200f/255f,60f/255f);
        }
        else {
            if (sr.eng == false) currentResult.text = "Последний результат:";
            else currentResult.text = "Last result:";
            currentResult.color = new Color(50f/255f,50f/255f,50f/255f);
        }
        
    }
    public void OnReturnButtonClick()
    {
        LevelSelect.SetActive(false);
        About.SetActive(false);
        MainMenu.SetActive(true);
        src.PlayOneShot(ui);
        //SceneManager.LoadScene("Menu");
    }
    public void OnQuitButtonClick()
    {
        src.PlayOneShot(ui);
        Application.Quit();
    }
    public void OnAboutButtonClick()
    {
        src.PlayOneShot(ui);
        About.SetActive(true);
        MainMenu.SetActive(false);

        //SceneManager.LoadScene("About");
    }
    public void OnLoRButtonClick()
    {
        if (ps.selLevel > ps.levelProgress)
        {

            preview.GetComponent<Image>().sprite = prsprites[0];

            if(sr.eng == false) underText.GetComponent<Text>().text = "Уровень в разработке..";
            else underText.GetComponent<Text>().text = "Level is in development..";
            currentScore.text = "-";
            bestScore.text = "-";
            //playButton.SetActive(false);
            playButton.GetComponent<Image>().color = new Color(128f/255f,128f/255f,128f/255f);
            
            if (sr.eng == false) currentResult.text = "Последний результат:";
            else currentResult.text = "Last result:";
            currentResult.color = new Color(50f/255f,50f/255f,50f/255f);
            playButtonBlank.SetActive(false);
        }
        else
        {
            preview.GetComponent<Image>().sprite = prsprites[ps.selLevel + 1];

            if (sr.eng == false) underText.GetComponent<Text>().text = levelDescText[ps.selLevel];
            else underText.GetComponent<Text>().text = englevelDescText[ps.selLevel];

            if (sr.current[ps.selLevel] == sr.records[ps.selLevel] && sr.current[ps.selLevel] != 0) {
                if (sr.eng == false) currentResult.text = "Новый рекорд!";
                else currentResult.text = "New record!";

                currentResult.color = new Color(0f,200f/255f,60f/255f);
            }
            else {
                if (sr.eng == false) currentResult.text = "Последний результат:";
                else currentResult.text = "Last result:";
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
          labelT.GetComponent<Text>().text = (level + ps.selLevel);
        }
        else
        {
           if(sr.eng == false) labelT.GetComponent<Text>().text = ("Обучение");
           else labelT.GetComponent<Text>().text = ("Tutorial");

        }
        src.PlayOneShot(ui);

    }

    public void OnRusLangButtonDown()
    {
        src.PlayOneShot(ui);
        sr.eng = false;
        SaveRecord();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnEngLangButtonDown()
    {
        src.PlayOneShot(ui);
        sr.eng = true;
        SaveRecord();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SaveRecord()
    {
        File.WriteAllText(Application.persistentDataPath + "/saveload.json", JsonUtility.ToJson(sr));
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
