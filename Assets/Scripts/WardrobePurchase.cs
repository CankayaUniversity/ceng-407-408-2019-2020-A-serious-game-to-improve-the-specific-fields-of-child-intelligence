using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WardrobePurchase : MonoBehaviour
{
    public Text[] btntxt;
    public int gold;
    public bool[] temp_unlocked_clothe = new bool[] { false, false, false };
    public int mascotindex;



    void Start()
    {
        GatherVariables();
        btntxt[3].text = "Your Gold: " + gold.ToString();

    }

    public void BuyWatermellon()
    {
        if (!temp_unlocked_clothe[0])
        {
            if (gold >= 100)
            {
                temp_unlocked_clothe[0] = true;
                gold = gold - 100;
                btntxt[0].text = "Unlocked";
                mascotindex = 0;
                btntxt[3].text = "Your Gold: " + gold.ToString();
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
    public void BuyYellowPepper()
    {
        if (!temp_unlocked_clothe[1])
        {
            if (gold >= 300)
            {
                temp_unlocked_clothe[1] = true;
                gold = gold - 300;
                btntxt[1].text = "Unlocked";
                mascotindex = 1;
                btntxt[3].text = "Your Gold: " + gold.ToString();
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
    public void BuyBanana()
    {
        if (!temp_unlocked_clothe[2])
        {
            if (gold >= 500)
            {
                temp_unlocked_clothe[2] = true;
                gold = gold - 500;
                btntxt[2].text = "Unlocked";
                mascotindex = 2;
                Debug.Log(gold);
                btntxt[3].text = "Your Gold: " + gold.ToString();
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
