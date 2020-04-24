using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    Collision C;
    private int top_fruit_id;
    public int basketid;
    FruitNumber Fn;
    private bool can_gather = false;
    public int gatherscore = 0;
    private void OnTriggerEnter2D(Collider2D fallenobj)
    {
        Fn = FindObjectOfType<FruitNumber>();

        if (fallenobj.gameObject.name == "MainCharacter")
        {
            can_gather = true;
            Debug.Log("Çarpma len");
        }
    }

    public void Gather()
    {
        if (can_gather)
        {
            C = FindObjectOfType<Collision>();
            top_fruit_id = C.gatheredfruits[C.fruitindex - 1];
            if (basketid == top_fruit_id)
            {
                Debug.Log("Helal. Doğru sandık.");
                Fn.DecreaseNumber();
                C.fruitindex--;
                gatherscore++;
                can_gather = false;

            }
            else
            {
                Debug.Log("Reis yanlış yapıyosun ya.");
                can_gather = false;
            }
        }
       
    }
    void Start()
    {
        
    }

    void Update()
    {
       
    }
}
