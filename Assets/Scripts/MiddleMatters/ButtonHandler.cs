using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private SpriteRenderer theSprite;
    private FocusColor Fc;
    public int pressedcolor;
    private Vector2 zero;
    Color correct;
    
   
    
    
    void OnMouseDown()
    {
    
    }

    void OnMouseUp()
    {
        if (Fc.gamestart)
        {
            Fc.CheckIfCorrect(pressedcolor);
            Fc.RandomMovement();
            Fc.ChangeColors();
        }
    }
    void Start()
    {
        
        Fc = FindObjectOfType<FocusColor>();
        theSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Fc.gameended)
        {
            zero.x = 0;
            zero.y = 0;
            GetComponent<BoxCollider2D>().size = zero; //In order to keep buttons not pressable
        }
        
    }
}
