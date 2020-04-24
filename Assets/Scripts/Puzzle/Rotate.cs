using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (!PuzzleGameControl.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
