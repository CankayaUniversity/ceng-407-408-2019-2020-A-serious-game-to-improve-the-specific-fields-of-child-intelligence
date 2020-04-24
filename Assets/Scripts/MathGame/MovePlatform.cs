using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided");
        speed = speed * -1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.GameIsPaused==false)
        gameObject.transform.position += new Vector3(speed, 0);
    }
}
