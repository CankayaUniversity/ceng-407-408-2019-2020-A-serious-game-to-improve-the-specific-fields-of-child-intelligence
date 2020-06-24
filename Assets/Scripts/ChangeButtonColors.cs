using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColors : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        this.GetComponentInChildren<Text>().color = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time, 1));
    }
    

    void OnMouseUp()
    {
        this.GetComponentInChildren<Text>().color = Color.red;
    }
    void Update()
    {
        
    }
}
