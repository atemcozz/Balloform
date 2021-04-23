using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class levelChange : MonoBehaviour
{
    storage st;
    public Sprite[] previewSprites;
    public string[] russianDescriptions;
    public string[] englishDescriptions;
    public GameObject preview, title, description, curentScore,bestScore, playButton,playButtonBlank;
    
    
    private void Start()
    {
        // st = st.LoadData(st);
       
    }
    public void OnEnable()
    {
        GetComponent<manager2>().LoadScreen += previewChange;
        GetComponent<manager2>().LoadScreen += descriptionChange;
        GetComponent<manager2>().LoadScreen += scoreChange;
        GetComponent<manager2>().LoadScreen += titleChange;
        GetComponent<manager2>().LoadScreen +=playButtonChange;
        /*
        manager.LoadScreen += titleChange;
        manager.LoadScreen += descriptionChange;
        manager.LoadScreen += scoreChange;
        manager.LoadScreen += playButtonChange;*/
    }
    public void OnDisable()
    {
        GetComponent<manager2>().LoadScreen -= previewChange;
        GetComponent<manager2>().LoadScreen -= descriptionChange;
        GetComponent<manager2>().LoadScreen -= scoreChange;
        GetComponent<manager2>().LoadScreen -= titleChange;
        GetComponent<manager2>().LoadScreen -= playButtonChange;
        /*
        manager.LoadScreen -= titleChange;
        manager.LoadScreen -= descriptionChange;
        manager.LoadScreen -= scoreChange;
        manager.LoadScreen -= playButtonChange;*/
    }
    public void previewChange(int number)
    {
        Debug.Log("prchange");
        if(number <= storage.data.currentLevel) preview.GetComponent<Image>().sprite = previewSprites[number + 1];
        else preview.GetComponent<Image>().sprite = previewSprites[0];
    }
    public void titleChange(int number)
    {
        if (number > 0) {

            if (storage.data.eng == false) title.GetComponent<Text>().text = "Уровень " + number;
            else title.GetComponent<Text>().text = "Level " + number;
        }
        else
        {
            if (storage.data.eng == false) title.GetComponent<Text>().text = "Обучение";
            else title.GetComponent<Text>().text = "Tutorial";
        }
    }
    public void descriptionChange(int number)
    {
        if(number <= storage.data.currentLevel)
        {
            description.GetComponent<Text>().text = storage.data.eng == true ? englishDescriptions[number] : russianDescriptions[number];
            playButton.SetActive(true);
            playButtonBlank.SetActive(true);
        }
        else
        {
            description.GetComponent<Text>().text = storage.data.eng == true ? "Complete previous level" :"Пройдите предыдущий уровень";
            playButton.SetActive(false);
            playButtonBlank.SetActive(false);
        }
    }
    public void scoreChange(int number)
    {
        curentScore.GetComponent<Text>().text = storage.data.eng == true ? "Last result:" : "Последний результат";
        bestScore.GetComponent<Text>().text = storage.data.eng == true ? "Best result:" : "Лучший результат";
        curentScore.transform.GetChild(0).GetComponent<Text>().text = storage.data.current[number].ToString();
        bestScore.transform.GetChild(0).GetComponent<Text>().text = storage.data.records[number].ToString();
    }
    public void playButtonChange(int number)
    {

    }
}
