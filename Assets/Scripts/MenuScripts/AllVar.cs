using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllVar : MonoBehaviour
{

    static public int totalgold = 1000;
    static public int mascotindex = 0;
    static public bool[] unlocked_clothe = new bool[] { false, false, false };
    public int saved_totalgold;
    public bool[] saved_unlocked_clothe = new bool[] { false, false, false };
    public int saved_mascotindex;
    static public bool loadflag = false;
    public GameObject Mascot;
    public Sprite[] mascotSprites = new Sprite[6];
    public Button routine_button;

    void Awake()
    {
        if (!loadflag)
        {
            LoadGame();
            loadflag = true;
        }
    }
    void Start()
    {
        Mascot.GetComponent<SpriteRenderer>().sprite = mascotSprites[mascotindex];
        if (!SceneTransition.routine_online)
        {
            routine_button.GetComponent<Button>().interactable = false;
            routine_button.GetComponentInChildren<Text>().text = "Routine Mode";
        }
    }

    public void SaveGame()
    {
        saved_mascotindex = mascotindex;
        saved_totalgold = totalgold;
        for (int i = 0; i < 3; i++)
        {
            saved_unlocked_clothe[i] = unlocked_clothe[i];
        }
        SaveLoad.SaveData(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveLoad.LoadData();
        try
        {
            saved_mascotindex = data.playermascotindex;
            saved_totalgold = data.playercurrency;
        }
        catch (NullReferenceException ex)
        {
            Debug.Log("myLight was not set in the inspector");
            
            for (int i = 0; i < 3; i++)
            {
                saved_unlocked_clothe[i] = data.player_unlocked_outfit[i];
            }

            for (int i = 0; i < 3; i++)
            {
                unlocked_clothe[i] = saved_unlocked_clothe[i];
            }
            mascotindex = saved_mascotindex;
            totalgold = saved_totalgold;

        }

        void QuitApp()
        {
            SaveGame();
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

        void RefreshValues()
        {
            mascotindex = 0;
            totalgold = 1000;
            unlocked_clothe = new bool[] { false, false, false };
            SceneManager.LoadScene("MainMenuMindGarden");
        }

    }
}
