using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    Rigidbody2D rb;

    [Range(0.2f, 2f)] public float speed = 0.5f;

    float dX, dY;

    Animator anim;

    static bool isDead;

    static bool moveAllow;

    static bool youWin;

    [SerializeField] GameObject winText;
    // Start is called before the first frame update
    void Start()
    {
        winText.gameObject.SetActive(false);

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

            Invoke("RestartScene",1f);
        }

        if (youWin)
        {
            winText.gameObject.SetActive(true);

            moveAllow = false;

            anim.SetBool("BallDead",true);

            Invoke("RestartScene", 2f);
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

    void RestartScene()
    {
        SceneManager.LoadScene("Scene01");
    }
}
