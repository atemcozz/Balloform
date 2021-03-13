using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformer : MonoBehaviour
{
    public int type = 2;
 
    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case 0:
                GetComponent<SpriteRenderer>().color = new Color(255f/255f, 255f/255f, 255f/255f, 190f/255f);
                break;
            case 1:
                GetComponent<SpriteRenderer>().color = new Color(255f/255f, 49f/255f, 58f/255f, 190f/255f);
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = new Color(106f/255f, 100f/255f, 100f/255f, 190f/255f);
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
