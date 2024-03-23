using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class addScripts : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<commonBalls>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
