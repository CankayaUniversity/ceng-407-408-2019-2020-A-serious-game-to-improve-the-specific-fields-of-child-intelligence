using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(0.2f, 2f)] public float speed = 0.5f;

    float dX, dY;

    Animator anim;

    static bool isDead;

    static bool moveAllow;

    static bool youWin;

    public Button nextgamebtn;

    public Button restartgamebtn;

    public Text winText;
    

  

    public void winBut()
    {
        youWin = true;
    }
    public void loseBut()
    {
        isDead = true;
    }
    // Start is called before the first frame update
    void Start()
    {
       // loseText.SetActive(false);
        winText.gameObject.SetActive(false);

        nextgamebtn.gameObject.SetActive(false);

        restartgamebtn.gameObject.SetActive(false);

        youWin = false;

        moveAllow = true;

        isDead = false;

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        anim.SetBool("BallDead", isDead);
    }

    // Update is called once per frame
    void Update()
    {
        dX = Input.acceleration.x * speed;
        dY = Input.acceleration.y * speed;

        if (isDead)
        {
            rb.velocity = new Vector2(0, 0);

            anim.SetBool("BallDead", isDead);

            restartgamebtn.gameObject.SetActive(true);

            //loseText.SetActive(true);
            winText.gameObject.SetActive(true);
            winText.text = "You Lose!";
        }

        if (youWin)
        {
            

            nextgamebtn.gameObject.SetActive(true);

            moveAllow = false;

            anim.SetBool("BallDead",true);

            //winText.SetActive(true);
            winText.gameObject.SetActive(true);
            winText.text = "You Win!";

        }
    }

    void FixedUpdate()
    {
        if (moveAllow)
        {
            rb.velocity = new Vector2(rb.velocity.x + dX, rb.velocity.y + dY);
        }
    }
    public static void setDead()
    {
        isDead = true;
    }

    public static void setWin()
    {
        
        youWin = true;
    }

   public void RestartScene()
    {
        SceneManager.LoadScene(7);
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
