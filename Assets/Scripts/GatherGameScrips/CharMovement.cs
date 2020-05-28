using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CharMovement : MonoBehaviour
{
    public float movementspeed = 6f;
    float velX;
    float velY;
    Rigidbody2D rigBody;
    Collision cs;
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
        }

        else if (cs.fruitindex == 2)
        {
            movementspeed = 5f;
        }
        else if (cs.fruitindex == 3)
        {
            movementspeed = 4.5f;
        }
        else if (cs.fruitindex == 4)
        {
            movementspeed = 4f;
        }
        else if (cs.fruitindex == 5)
        {
            movementspeed = 3.5f;
        }
        else if (cs.fruitindex == 6)
        {
            movementspeed = 3f;
        }
        else if (cs.fruitindex == 0)
        {
            movementspeed = 6f;
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
