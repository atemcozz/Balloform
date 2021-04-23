using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTranslate : MonoBehaviour
{
    public string russianText, englishText;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        
        text = GetComponent<Text>();
        if (storage.data.eng == false)
        {
            text.text = russianText;
        }
        else
        {
            text.text = englishText;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
