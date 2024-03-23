using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelName : MonoBehaviour
{
    public Text labelText;
    [SerializeField]
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        labelText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       if (obj.GetComponent<levelSelect>().ps.selLevel != 0)
        {
          labelText.text = ("Уровень " + obj.GetComponent<levelSelect>().ps.selLevel);
        }
       else
        {
            labelText.text = ("Обучение" );
        }
       
    }
}
