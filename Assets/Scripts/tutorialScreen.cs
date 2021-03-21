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
        russprites = Resources.LoadAll<Sprite>("tutorial/rus");
        engsprites = Resources.LoadAll<Sprite>("tutorial/eng");
        if (sr.eng == false) image.sprite = russprites[selLevel];
        else image.sprite = engsprites[selLevel];
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnNextButtonDown()
    {
        src.PlayOneShot(ui);
        SaveRecords sr = new SaveRecords();
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        if (selLevel < 7)
        {
            selLevel++;
            if (sr.eng == false) image.sprite = russprites[selLevel];
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
        SaveRecords sr = new SaveRecords();
        if (File.Exists(Application.persistentDataPath + "/saveload.json"))
        {
            sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
        }
        if (selLevel > 0)
        {
            selLevel--;
            if (sr.eng == false) image.sprite = russprites[selLevel];
            else image.sprite = engsprites[selLevel];
        }
        else
        {
            PlayerPrefs.SetInt("menu", 1);
            SceneManager.LoadScene("Menu");
        }


        
    }
}
