using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
            FindObjectOfType<SliderMath>().collideAnother();
            Debug.Log("collided");
        
    }
}

