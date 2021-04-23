using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bonusCodeInputField : MonoBehaviour
{
    public InputField inputField;
    //public Button confirmButton;
    public string[] bonusLabels;
    // Start is called before the first frame update
    void Start()
    {
        //inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnConfirmButtonDown()
    {
        for(int i = 0; i < bonusLabels.Length; i++)
        {
            if (inputField.text == bonusLabels[i])
                SceneManager.LoadScene("level_debug");
        }
    }
}
