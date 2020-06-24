using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;


public class CharMovement : MonoBehaviour
{
    public float movementspeed = 6f;
    float velX;
    float velY;
    Rigidbody2D rigBody;
    Collision cs;
    public Text speedtxt;
    int cnt;
    //bool facingright = true;
   
    void Start()
    {
        cs = FindObjectOfType<Collision>();
        rigBody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if (cs.fruitindex == 1)
        {
            
            movementspeed = 5.5f;
            speedtxt.text = "Speed: 6";
        }

        else if (cs.fruitindex == 2)
        {
            movementspeed = 5f;
            speedtxt.text = "Speed: 5";
        }
        else if (cs.fruitindex == 3)
        {
            movementspeed = 4.5f;
            speedtxt.text = "Speed: 4";
        }
        else if (cs.fruitindex == 4)
        {
            movementspeed = 4f;
            speedtxt.text = "Speed: 3";
        }
        else if (cs.fruitindex == 5)
        {
            movementspeed = 3.5f;
            speedtxt.text = "Speed: 2";
        }
        else if (cs.fruitindex == 6)
        {
            movementspeed = 3f;
            speedtxt.text = "Speed: 1";
        }
        else if (cs.fruitindex == 0)
        {
            movementspeed = 6f;
            speedtxt.text = "Speed: 7";
        }
     

        velX = CrossPlatformInputManager.GetAxis("Horizontal")*movementspeed;
        rigBody.velocity = new Vector2(velX, 0f);
    }

    public void Move()
    {
        velX = CrossPlatformInputManager.GetAxis("Horizontal");
        //velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * movementspeed, 0f);
    }

    //void LateUpdate() //This is for flipping sprite
    //{
    //    Vector3 localScale = transform.localScale;
    //    if(velX > 0)
    //    {
    //        facingright = true;
    //    }
    //    else
    //    {
    //        facingright = false;
    //    }

    //    if (facingright && localScale.x < 0 || !facingright && localScale.x > 0)
    //    {
    //        localScale.x *= -1;
    //    }

    //    transform.localScale = localScale;
    //}
}
