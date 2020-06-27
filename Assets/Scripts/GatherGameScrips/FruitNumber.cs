using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitNumber : MonoBehaviour
{
    public Sprite[] currentfruitnumber = new Sprite[7];
    private int spriteindex= 0;
    public GameObject number;


    public void IncreaseNumber()
    {

        spriteindex++;
        number.GetComponent<SpriteRenderer>().sprite = currentfruitnumber[spriteindex];
    }

    public void DecreaseNumber()
    {
        spriteindex--;
        number.GetComponent<SpriteRenderer>().sprite = currentfruitnumber[spriteindex];
    }
}
