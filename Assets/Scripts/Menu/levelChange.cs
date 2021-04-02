using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class levelChange : MonoBehaviour
{
    storage st = new storage();
    manager2 manager = new manager2();
    public Sprite[] previewSprites;
    public string[] russianDescriptions;
    public string[] englishDescriptions;
    public GameObject preview, title, description, curentScore,bestScore;
    private void Start()
    {
       
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
        if(number <= st.currentLevel) preview.GetComponent<Image>().sprite = previewSprites[number + 1];
        else preview.GetComponent<Image>().sprite = previewSprites[0];
    }
    public void titleChange(int number)
    {
        if (number > 0) {

            if (st.eng == false) title.GetComponent<Text>().text = "Уровень " + number;
            else title.GetComponent<Text>().text = "Level " + number;
        }
        else
        {
            if (st.eng == false) title.GetComponent<Text>().text = "Обучение";
            else title.GetComponent<Text>().text = "Tutorial";
        }
    }
    public void descriptionChange(int number)
    {
        if(number <= st.currentLevel)
        {
            description.GetComponent<Text>().text = st.eng == true ? englishDescriptions[number] : russianDescriptions[number];
        }
        else
        {
            description.GetComponent<Text>().text = st.eng == true ? "Level is in development" :"Уровень в разработке";
        }
    }
    public void scoreChange(int number)
    {
        curentScore.GetComponent<Text>().text = st.eng == true ? "Last result:" : "Последний результат";
        bestScore.GetComponent<Text>().text = st.eng == true ? "Best result:" : "Лучший результат";
        curentScore.transform.GetChild(0).GetComponent<Text>().text = st.current[number].ToString();
    }
    public void playButtonChange(int number)
    {

    }
}
