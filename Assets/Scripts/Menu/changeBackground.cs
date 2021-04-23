using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeBackground : MonoBehaviour
{
    public int type;
    // Start is called before the first frame update
    void Awake()
    {
        type = Random.Range(0, 4);
    }

    // Update is called once per frame
    
}
