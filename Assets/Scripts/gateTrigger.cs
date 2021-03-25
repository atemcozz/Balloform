using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gateTrigger : MonoBehaviour
{
    public GameObject gate;
    public GameObject barrier;
    Vector2 gateTargetPosStart;
    Vector2 gateTargetPosEnd;
    bool isMoving;
    bool isCompleted;
    public Text timer;
    public int timerTime = 60;
    public GameObject bossobj;
    public GameObject triggerMove;
    // Start is called before the first frame update
    void Start()
    {
        gateTargetPosStart = new Vector2(gate.transform.position.x, 37f);
        gateTargetPosEnd = new Vector2(gate.transform.position.x, 31f);
        if (PlayerPrefs.GetInt("boss") == 2)
        {
            bossobj.transform.position = new Vector2(385f, bossobj.transform.position.y);
            triggerMove.transform.position = new Vector2(365f, triggerMove.transform.position.y);
            triggerMove.GetComponent<triggerMove>().isMoving = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            gate.transform.position = Vector2.MoveTowards(gate.transform.position, gateTargetPosEnd, Time.deltaTime * 10f);
            
        }
        else
        {
            gate.transform.position = Vector2.MoveTowards(gate.transform.position, gateTargetPosStart, Time.deltaTime * 10f);
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isCompleted == false)
        {
            PlayerPrefs.SetInt("boss", 2);
            bossobj.transform.position = new Vector2(385f, bossobj.transform.position.y);
            triggerMove.transform.position = new Vector2(365f, triggerMove.transform.position.y);
            triggerMove.GetComponent<triggerMove>().isMoving = 0;
            barrier.SetActive(false);
            isMoving = true;
            timer.gameObject.SetActive(true);
            StartCoroutine(Timer());
            isCompleted = true;
        }
    }
    IEnumerator Timer()
    {

        for (; timerTime > 0; timerTime--)
        {
            timer.text = timerTime.ToString();
            yield return new WaitForSeconds(1f);
        }
        
        isMoving = false;
        timer.gameObject.SetActive(false);
    }
}
