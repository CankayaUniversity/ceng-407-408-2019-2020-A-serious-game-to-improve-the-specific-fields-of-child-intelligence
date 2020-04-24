using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenObjects : MonoBehaviour
{
    
    
    private Vector2 screenBounds;
    public int fallenobj_id;



    private void OnTriggerEnter2D(Collider2D fallenobj)
    {
        
        Destroy(this.gameObject);
    }

    IEnumerator ObjectDestroyed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
        }
    }

    void Start()
    {
        StartCoroutine(ObjectDestroyed());
    }
}