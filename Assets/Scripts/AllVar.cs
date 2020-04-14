using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllVar : MonoBehaviour
{
    static public  int totalgold = 1000;
    static public int mascotindex = 0;
    static public bool[] unlocked_clothe = new bool[] { false, false, false };
    public int saved_totalgold;
    public bool[] saved_unlocked_clothe = new bool[] { false, false, false };
    public int saved_mascotindex;
    static public bool loadflag = false;

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
        Debug.Log(unlocked_clothe[0]);
        Debug.Log(unlocked_clothe[1]);
        Debug.Log(unlocked_clothe[2]);
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
        saved_mascotindex = data.playermascotindex;
        saved_totalgold = data.playercurrency;
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

    public void QuitApp()
    {
        SaveGame();
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void RefreshValues()
    {
        mascotindex = 0;
        totalgold = 1000;
        unlocked_clothe = new bool[] { false, false, false };
        SceneManager.LoadScene("MainMenuMindGarden");
    }

}
