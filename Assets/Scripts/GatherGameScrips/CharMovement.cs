using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CharMovement : MonoBehaviour
{
    public float movementspeed = 3f;
    float velX;
    float velY;
    Rigidbody2D rigBody;
    //bool facingright = true;
   
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
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
