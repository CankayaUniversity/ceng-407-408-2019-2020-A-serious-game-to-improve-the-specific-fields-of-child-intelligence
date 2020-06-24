using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobePurchase : MonoBehaviour
{
    public Text[] btntxt;
    public int gold;
    public bool[] temp_unlocked_clothe = new bool[] { false, false, false, false, false, false };
    public int mascotindex;



    void Start()
    {
        GatherVariables();
        btntxt[6].text = " " + gold.ToString();

    }

    void Update()
    {
        SendVariables();
    }

    public void BuySquirrel()
    {
        if (!temp_unlocked_clothe[0])
        {
            if (gold >= 100)
            {
                temp_unlocked_clothe[0] = true;
                gold = gold - 100;
                btntxt[0].text = "Use";
                mascotindex = 0;
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }
          
        }
        else
        {
            mascotindex = 0;
            Debug.Log("You already purchased that item.");
        }
        
    }
    public void BuyMouse()
    {
        if (!temp_unlocked_clothe[1])
        {
            if (gold >= 200)
            {
                temp_unlocked_clothe[1] = true;
                gold = gold - 200;
                btntxt[1].text = "Use";
                mascotindex = 1;
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }

        }
        else
        {
            mascotindex = 1;
            Debug.Log("You already purchased that item.");
        }
    }
    public void BuyBear()
    {
        if (!temp_unlocked_clothe[2])
        {
            if (gold >= 300)
            {
                temp_unlocked_clothe[2] = true;
                gold = gold - 300;
                btntxt[2].text = "Use";
                mascotindex = 2;
                Debug.Log(gold);
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }

        }
        else
        {
            mascotindex = 2;
            Debug.Log("You already purchased that item.");
        }
    }

    public void BuyFox()
    {
        if (!temp_unlocked_clothe[3])
        {
            if (gold >= 400)
            {
                temp_unlocked_clothe[3] = true;
                gold = gold - 400;
                btntxt[3].text = "Use";
                mascotindex = 3;
                Debug.Log(gold);
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }

        }
        else
        {
            mascotindex = 2;
            Debug.Log("You already purchased that item.");
        }
    }

    public void BuyKoala()
    {
        if (!temp_unlocked_clothe[4])
        {
            if (gold >= 500)
            {
                temp_unlocked_clothe[4] = true;
                gold = gold - 500;
                btntxt[4].text = "Use";
                mascotindex = 4;
                Debug.Log(gold);
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }

        }
        else
        {
            mascotindex = 4;
            Debug.Log("You already purchased that item.");
        }
    }

    public void BuyPanda()
    {
        if (!temp_unlocked_clothe[5])
        {
            if (gold >= 600)
            {
                temp_unlocked_clothe[5] = true;
                gold = gold - 600;
                btntxt[5].text = "Use";
                mascotindex = 5;
                Debug.Log(gold);
                btntxt[6].text = "" + gold.ToString();
            }
            else
            {
                Debug.Log("You don't have enough gold.");
            }

        }
        else
        {
            mascotindex = 5;
            Debug.Log("You already purchased that item.");
        }
    }
    public void BackToMainMenu()
    {
        SendVariables();
        SceneManager.LoadScene("MainMenuMindGarden");
    }

    private void GatherVariables()
    {
        gold = AllVar.totalgold;
        mascotindex = AllVar.mascotindex;
        for (int i = 0; i < 3; i++)
        {
            temp_unlocked_clothe[i] = AllVar.unlocked_clothe[i];
            if (temp_unlocked_clothe[i])
            {
                btntxt[i].text = "Unlocked";
            }
        }
    }

    private void SendVariables()
    {
        AllVar.mascotindex = mascotindex;
        Debug.Log("Gönderilen gold: " + gold);
        AllVar.totalgold = gold;
        for (int i = 0; i < 3; i++)
        {
            AllVar.unlocked_clothe[i] = temp_unlocked_clothe[i];
        }
    }
}
