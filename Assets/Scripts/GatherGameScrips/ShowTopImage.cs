using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTopImage : MonoBehaviour
{
    public Sprite[] fruitimages;
    int currentimage_index;
    Collision C;
    void Start()
    {
        C = FindObjectOfType<Collision>();
    }
    void Update()
    {
        if (C.fruitindex <= 0)
        {
          GetComponent<SpriteRenderer>().sprite = fruitimages[0];
        }
        else
        {
            currentimage_index = C.gatheredfruits[C.fruitindex - 1];
            GetComponent<SpriteRenderer>().sprite = fruitimages[currentimage_index];
        }
        
    }
}
