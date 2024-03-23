using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class languageChangeButton : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnLanguageButtonClick(Button button)
    {
        if(button.gameObject.name == "rus")
        {
            storage.data.eng = false;
        }
        else
        {
            storage.data.eng = true;
        }
        
        storage.SaveRecord();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
