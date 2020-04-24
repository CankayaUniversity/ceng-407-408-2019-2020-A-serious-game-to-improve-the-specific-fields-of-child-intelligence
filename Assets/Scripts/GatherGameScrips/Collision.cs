using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
  public int[] gatheredfruits = new int[6];
   private int fallenfruits;
   public int fruitindex = 0;
   Vector2 holdingPoint;
   public bool gathered = false;
   public  GameObject mainchar;
    FruitNumber Fc;
    
    
    public bool destroyflag = false;
 
   public void OnTriggerEnter2D(Collider2D fallenobj)
    {
        
        if (fallenobj.gameObject.tag == "Fruit")
        {
            fallenfruits = fallenobj.gameObject.GetComponent<FallenObjects>().fallenobj_id;
            
            gathered = true;
            destroyflag = true;
            Fc = FindObjectOfType<FruitNumber>();
            Fc.IncreaseNumber();
            Debug.Log(fallenobj.name);
            if (fruitindex <=5)
            {
                if (fallenfruits == 1)
                {
                    gatheredfruits[fruitindex] = 1;
                }
                else if (fallenfruits == 2)
                {
                    gatheredfruits[fruitindex] = 2;
                }
                else
                    gatheredfruits[fruitindex] = 3;
            }
            else
            {
                Debug.Log("Yerin doldu.");
            }
        }
    }

   

    void Update()
    {
        if (gathered)
        {
          fruitindex++;
          gathered = false;
        }


    }
}
