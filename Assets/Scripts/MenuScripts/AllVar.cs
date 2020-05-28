using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class AllVar : MonoBehaviour
{
    int cnt;
    static public bool[] app_open_count = new bool[] { false, false, false };
    public bool[] app_open_count_for_load = new bool[] { false, false, false };
    static public int app_open_index;
    static public  int totalgold = 0;
    static public int mascotindex = 0;
    static public bool[] unlocked_clothe = new bool[] { false, false, false };
    public int saved_totalgold;
    public bool[] saved_unlocked_clothe = new bool[] { false, false, false };
    public int saved_mascotindex;
    static public bool loadflag = false;
    public GameObject Mascot;
    public Sprite[] mascotSprites = new Sprite[6];
    public Button routine_button;
    public static bool game_accesable = true;
    private static bool game_opened = false;
    RealTimeCounter RTC;
    public GameObject denypanel;
    public static int routine_mode_score = 0;
    int counter;
    public bool routine_online_for_save = true;

    void Awake()
    {
        if (!loadflag)
        {
            LoadGame();
            loadflag = true;
        }

        if (HourDetect.resetflag)
        {
            app_open_count = new bool[] { false, false, false };
            HourDetect.resetflag = false;
        }

        if (!game_opened) // Her menüye dönüldüğünde aşağıdaki for çalışmasın diye
        {
            for (int i = 0; i < 3; i++) //Oyuna günlük kaç kere girildiğini sayan for.
            {
                game_opened = true;
                Debug.Log("For'a girdim");
                if (!app_open_count[i])
                {
                    Debug.Log("If'e girdim");
                    app_open_count[i] = true;
                    break;
                }
                counter = i;
            }
            if (counter == 2)
            {
                game_accesable = false; //For üç kere döndüğünde oyuna girilme hakkı bitmiş demektir.
                Debug.Log("Oyuna girişin kapandı");

            }
          
        }

        if (!game_accesable)
        {
            denypanel.gameObject.SetActive(true);
        }

        SaveGame();


    }
    void Start()
    {
        if (Time.time >= 1800)
        {
            denypanel.gameObject.SetActive(true);
        }
        Debug.Log(Time.time);
        Mascot.GetComponent<SpriteRenderer>().sprite = mascotSprites[mascotindex];
        if (!SceneTransition.routine_online)
        {
            routine_button.GetComponent<Button>().interactable = false;
            routine_button.GetComponentInChildren<Text>().text = "Routine Mode" ;
        }
        if (PlayerPrefs.GetInt("Rutin") == 1)
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
        for (int i = 0; i < 3; i++)
        {
            app_open_count_for_load[i] = app_open_count[i];
        }
        SaveLoad.SaveData(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveLoad.LoadData();
        if (data.playermascotindex!=null)
        {
            saved_mascotindex = data.playermascotindex;
        }
        
        saved_totalgold = data.playercurrency;
        for (int i = 0; i < 3; i++)
        {
            saved_unlocked_clothe[i] = data.player_unlocked_outfit[i];
        }

        for (int i = 0; i < 3; i++)
        {
            unlocked_clothe[i] = saved_unlocked_clothe[i];
        }
        for (int i = 0; i < 3; i++)
        {
            app_open_count[i] = data.player_app_open_count[i];
        }
        mascotindex = saved_mascotindex;
        totalgold = saved_totalgold;

    }

    public void QuitApp()
    {
        SaveGame();
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void RefreshValues()
    {
        PlayerPrefs.SetInt("Rutin",0);
        mascotindex = 0;
        totalgold = 1000;
        unlocked_clothe = new bool[] { false, false, false };
        app_open_count = new bool[] { false, false, false };
        SaveGame();
        SceneManager.LoadScene("MainMenuMindGarden");
    }

}
