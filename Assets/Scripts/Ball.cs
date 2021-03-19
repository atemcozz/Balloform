using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    
    public float score = 1000f;
    public float speed = 1000f;
    public float moveInput;
    private float mobileInput;
    public float jumpForce = 1000f;
    public bool isGround = true;
    public Transform groundCheck;
    public float checkRadius = 0.3f;
    public LayerMask whatIsGround;
    public Transform Camera;
    private bool isInWater = false;
    public Save save = new Save();
    public SaveRecords sr = new SaveRecords();
    public Sprite paper;
    public Sprite defstate;
    public Sprite stone;
    public Image image;
    Text ScoreText;
   
    //Audio
    public AudioSource src;
    public AudioSource loopsrc;
    public AudioClip normalLoop;
    public AudioClip stoneLoop;
    public AudioClip paperLoop;
    public AudioClip hit;
    public AudioClip paperHit;
    public AudioClip checkpoint;
    public AudioClip waterInto;
    public AudioClip waterOut;
    public AudioClip lose;
    public AudioClip portal;
    public AudioClip transformer;
    public AudioClip blob;
    //public AudioClip roll;
    //AudioSource source;
   
    private string path;
    int levelIndex;
    [System.Serializable]
    public class Save
    {
         public int ballState = 1;
         public Vector2 checkpos;
    }
    public class SaveRecords
    {

        public List<float> records = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        public List<float> current = new List<float>() {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    }


    // Start is called before the first frame update
    void Start()
    {
        
        levelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        ScoreText = GameObject.Find("scoreText").GetComponent<Text>();
        blob = Resources.Load<AudioClip>("Sounds/blob");
       if(PlayerPrefs.HasKey("score")){
       score = PlayerPrefs.GetFloat("score");
         }
        rb = GetComponent<Rigidbody2D>();
       if(File.Exists(Application.persistentDataPath + "/saveload.json"))
       {
           sr = JsonUtility.FromJson<SaveRecords>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));
       }



        if (PlayerPrefs.HasKey("posX")){
            save.checkpos = new Vector2(PlayerPrefs.GetFloat("posX"),PlayerPrefs.GetFloat("posY"));
            rb.transform.position = new Vector2(save.checkpos.x, save.checkpos.y);
            save.ballState = PlayerPrefs.GetInt("ballstate");
            changeballState(save.ballState);
        }
        //source = GetComponent<AudioSource>();
        StartCoroutine(Score());
        // LINUX
        StartCoroutine(UnFade());
        Color color = image.color;
        image.color = color;

        //src = GetComponent<AudioSource>();
        //loopsrc = GetComponent<AudioSource>();

        chSound();
        loopsrc.loop = true;
        
    }


    public void SaveRecord()
    {

        File.WriteAllText(Application.persistentDataPath + "/saveload.json", JsonUtility.ToJson(sr));
    }









    // Update is called once per frame
    void Update()
    {
        
        checkGround();
        Camera.position = new Vector3(rb.transform.position.x, rb.transform.position.y, -10); //�������� ������
        groundCheck.transform.position = new Vector2(rb.transform.position.x, rb.transform.position.y-(GetComponent<CircleCollider2D>().bounds.size.y/2)); //����� ��� �������� ��������
        moveInput = Input.GetAxis("Horizontal");

        rb.AddForce(new Vector2(moveInput * speed * Time.deltaTime, 0f)); //�������� ����
        rb.AddForce(new Vector2(mobileInput * speed * Time.deltaTime, 0f));

        //(Input.GetKeyDown(KeyCode.Return))
        //if ((Input.GetKeyDown(KeyCode.Space)) && (isGround == true || (isInWater == true && save.ballState == 1)))

        //if ((Input.GetKeyDown(KeyCode.Space)) && (isGround == true || (isInWater == true && save.ballState == 1)))
        //if ( ( (Input.GetKeyDown(KeyCode.Space)) || (Input.GetMouseButtonDown(0))) && (isGround == true || (isInWater == true && save.ballState == 1)))
        if ((Input.GetKeyDown(KeyCode.Space)) && (isGround == true || (isInWater == true && save.ballState == 1)))
        {
            
            
               rb.AddForce(new Vector2(0f, jumpForce));

            
           
        }

        /*if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(sr.records[levelIndex]);

        }*/

        loopsrc.pitch = rb.velocity.x / 7;
       
        if (!loopsrc.isPlaying && isGround){
          // if (save.ballState == 1 || save.ballState == 2) src.PlayOneShot(hit, -rb.velocity.y / 10 * rb.mass);
          // else src.PlayOneShot(paperHit);
            loopsrc.Play();
        }    
        if(loopsrc.isPlaying && !isGround){
            loopsrc.Stop();
        }
        
      
     // Debug.Log("Magnitude: " + rb.velocity.magnitude + "Velocity y: " + rb.velocity.y);
    }

    void chSound()
    {
        switch (save.ballState)
        {
            case 0:
                loopsrc.clip = paperLoop;
                break;
            case 1:
                loopsrc.clip = normalLoop;
                break;
            case 2:
                loopsrc.clip = stoneLoop;
                break;
        }
    }
    void checkGround()
        {
            isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        }

        public void OnCollisionEnter2D(Collision2D other) {

        
            if ((save.ballState == 1 || save.ballState == 2) && rb.velocity.magnitude > 1.5f && other.gameObject.layer != 7) src.PlayOneShot(hit, rb.velocity.magnitude/10);
           else if (save.ballState == 0) src.PlayOneShot(paperHit);
        
            
        
            



        




    }
        private void OnCollisionExit2D(Collision2D other) {
            
        }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "portalCheck")
        {


            if(score > sr.records[levelIndex])
            {
                sr.records[levelIndex] = score;
            }
            sr.current[levelIndex] = score;
            SaveRecord();
            Debug.Log(levelIndex + "level");
            src.PlayOneShot(portal);
            StartCoroutine(Fade(true));
        }
        if (other.gameObject.tag == "bonus")
        {
           score += 400;
            src.PlayOneShot(blob);
            StartCoroutine(ChangeScoreColor());

        }
        
        if (other.gameObject.tag == "trap")
        {
            src.PlayOneShot(lose, 3);
            PlayerPrefs.SetInt("ballstate", save.ballState);
            rb.bodyType = RigidbodyType2D.Static;
            
            // LINUX 
            StartCoroutine(Fade(false));

            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
            

        }
       
        if (other.gameObject.tag == "speed_gel")
        {

            speed *= 2;


        }
        if (other.gameObject.tag == "water")
        {
            src.PlayOneShot(waterInto, rb.velocity.magnitude / 10);
            rb.gravityScale /= 5;
            speed /= 2;
            jumpForce /= 2;

            isInWater = true;
            
        }
        if (other.gameObject.tag == "finish")
        {

            
            SceneManager.LoadScene("Menu");

        }

        if (other.gameObject.tag == "transformer")
        {
            if (other.gameObject.GetComponent<transformer>().type != save.ballState) src.PlayOneShot(transformer);
            switch (other.gameObject.GetComponent<transformer>().type)
            {
                case 0:
                    save.ballState = 0;
                    break;
                case 1:
                    save.ballState = 1;
                    break;
                case 2:
                    save.ballState = 2;
                    break;
            }
            changeballState(save.ballState);
           // Debug.Log(save.ballState);
            
        }

        if (other.gameObject.tag == "slowmo")
        {
            Time.timeScale = 0.5f;

        }

        if (other.gameObject.tag == "checkpoint")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().color != new Color(0f, 78f / 255f, 1f, 123f / 255f))
            {
              src.PlayOneShot(checkpoint, 0.5f);
            }

            
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 78f / 255f, 1f, 123f / 255f);
            //save.checkpos = other.gameObject.GetComponent<checkpoint>().chCol.transform.position;
            //SaveData();
            
            PlayerPrefs.SetFloat("posX", other.gameObject.GetComponent<checkpoint>().chCol.transform.position.x);
            PlayerPrefs.SetFloat("posY", other.gameObject.GetComponent<checkpoint>().chCol.transform.position.y);
           // Debug.Log(save.checkpos);
            




        }

    }
    
    void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "water")
        {
            src.PlayOneShot(waterOut);
            rb.gravityScale *= 5;
            speed *= 2;
            jumpForce *= 2;
            isInWater = false;

        }
        if (other.gameObject.tag == "speed_gel")
        {

            speed /= 2;


        }
        if (other.gameObject.tag == "slowmo")
        {
            Time.timeScale = 1f;

        }
       
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "water")
        {
           
            
        }
        if (other.gameObject.tag == "portal")
        {
            rb.mass = 1;
            speed = 0;
            jumpForce = 0;
            transform.position = Vector2.MoveTowards(transform.position, other.gameObject.transform.position, 0.2f);
           

        }


    }

    public void OnLeftButtonDown()
    {
        mobileInput = -1;
    }
    public void OnRightButtonDown()
    {
        mobileInput = 1;
    }

    public void OnButtonUp()
    {
        mobileInput = 0;
    }

    public void OnJumpButtonDown()
    {
        if(isGround == true || (isInWater == true && save.ballState == 1))
        {
            rb.AddForce(new Vector2(0f, jumpForce));

        }
    }

    void changeballState(int state)
    {
        if(isInWater == false) { 

        switch (state)
        {
            case 0:
                rb.mass = 0.05f;
                speed = 50f;
                jumpForce = 30f;
                rb.gravityScale = 0.5f;
                loopsrc.clip = paperLoop;
                GetComponent<SpriteRenderer>().sprite = paper;
                break;


            case 1:
                rb.mass = 1f;
                speed = 750f;
                jumpForce = 500f;
                rb.gravityScale = 1.0f;
                loopsrc.clip = normalLoop;
                GetComponent<SpriteRenderer>().sprite = defstate;
                break;

            case 2:
                rb.mass = 5f;
                speed = 3000f;
                jumpForce = 1500f;
                rb.gravityScale = 1.5f;
                loopsrc.clip = stoneLoop;
                GetComponent<SpriteRenderer>().sprite = stone;
                break;


        }

        }
        else
        {
            switch (state)
            {
                case 0:
                    rb.mass = 0.05f;
                    speed = 50f/2;
                    jumpForce = 30f/2;
                    rb.gravityScale = 0.5f/5;
                    GetComponent<SpriteRenderer>().sprite = paper;
                    loopsrc.clip = paperLoop;
                    break;


                case 1:
                    rb.mass = 1f;
                    speed = 750f/2;
                    jumpForce = 500f/2;
                    rb.gravityScale = 1.0f/5;
                    loopsrc.clip = normalLoop;
                    GetComponent<SpriteRenderer>().sprite = defstate;
                    break;

                case 2:
                    rb.mass = 5f;
                    speed = 3000f/2;
                    jumpForce = 1500f/2;
                    rb.gravityScale = 1.5f/5;
                    loopsrc.clip = stoneLoop;
                    GetComponent<SpriteRenderer>().sprite = stone;
                    break;


            }
        }
    }
    void OnApplicationQuit()
    {
        
    }

    /* private void OnCollisionEnter2D(Collision2D other)
     {
         if (other.gameObject.tag == "ground")
         {
             source.PlayOneShot(roll);
         }
     }*/
    IEnumerator Fade(bool isFinish)
    {
        
        for (float f = 0f; f <= 1f; f += 0.03f)
        {
            Color color = image.color;
            color.a = f;
            image.color = color;
            Debug.Log(f);
            yield return new WaitForSeconds(0.01f);

        }
        Color fcolor = image.color;
        fcolor.a = 1f;
        image.color = fcolor;

        if (isFinish)
        {
            yield return new WaitForSeconds(1f);
            PlayerPrefs.SetInt("menu", 1);
            SceneManager.LoadScene("Menu");
        }
         
        else {
        PlayerPrefs.SetFloat("score", score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
         
         
        
       

    }
    IEnumerator UnFade()
    {
        for (float f = 1f; f > 0f; f -= 0.05f)
        {
            Color color = image.color;
            color.a = f;
            image.color = color;
            //Debug.Log(f);
            yield return new WaitForSeconds(0.01f);

        }
        Color fcolor = image.color;
        fcolor.a = 0f;
        image.color = fcolor;
    }
    IEnumerator ChangeScoreColor(){

        ScoreText.color = new Color(0f,200f/255f,60f/255f);

        yield return new WaitForSeconds(0.25f);
        ScoreText.color = new Color(50f/255f,50f/255f,50f/255f);




    }


     IEnumerator Score(){
      for( ; ; ){
           
              if (score > 0) score--;
                yield return new WaitForSeconds(0.3f);
            
       
}


}
} 