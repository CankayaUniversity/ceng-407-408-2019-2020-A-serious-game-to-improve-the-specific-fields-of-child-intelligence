using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class AllVar : MonoBehaviour
{
    int cnt;
    static public bool[] app_open_count = new bool[] { false, false, false };
    public bool[] app_open_count_for_load = new bool[] { false, false, false };
    static public int app_open_index;
    static public  int totalgold = 0;
    static public int mascotindex = 0;
    static public bool[] unlocked_clothe = new bool[] { true, false, false, false, false, false };
    public int saved_totalgold;
    public bool[] saved_unlocked_clothe = new bool[] { true, false, false, false, false, false };
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
    int fileflag = 0;
    Records records;
    RecordsMM recordsmm;
    RecordsMG recordsmg;
    public Text timer;
    public float sessionTime =0f;
    public float min;
    public float sec;
    public Image routineoff;
    private void Update()
    {
        sessionTime = 900- (int)Time.time;
        min = (int)sessionTime / 60;
        sec = (int)sessionTime % 60;
        timer.text =   min.ToString() + " : " + sec.ToString();
        if (Time.time >= 900)
        {
            denypanel.gameObject.SetActive(true);
            timer.gameObject.SetActive(false);
        }

       
        
    }
    void Awake()
    {

        if (!PlayerPrefs.HasKey("FileFlag"))
        {
            PlayerPrefs.SetInt("FileFlag", fileflag);
            records = new Records();
            recordsmm = new RecordsMM();
            recordsmg = new RecordsMG();
            string path = "/PlayerRecords.json";
            string jsonData = JsonUtility.ToJson(records, true);
            File.WriteAllText(Application.persistentDataPath + path, jsonData);
            path = "/PlayerRecordsMM.json";
            string jsonData1 = JsonUtility.ToJson(recordsmm, true);
            File.WriteAllText(Application.persistentDataPath + path, jsonData1);
            path = "/PlayerRecordsMG.json";
            string jsonData2 = JsonUtility.ToJson(recordsmg, true);
            File.WriteAllText(Application.persistentDataPath + path, jsonData2);
            SaveGame();
            Debug.Log("Dosyalar Oluşturuldu.");
        } 

        //PlayerPrefs.DeleteKey("FileFlag");
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
       
        Debug.Log(Time.time);
        Mascot.GetComponent<SpriteRenderer>().sprite = mascotSprites[mascotindex];
        if (!SceneTransition.routine_array_created)
        {
            routine_button.GetComponent<Button>().interactable = false;
        }
        if (PlayerPrefs.GetInt("Rutin") == 1)
        {
            routineoff.gameObject.SetActive(true);
            routine_button.GetComponent<Button>().interactable = false;
        }
    } 

    public void SaveGame()
    {
        saved_mascotindex = mascotindex;
        saved_totalgold = totalgold;
        for (int i = 0; i < 6; i++)
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
        for (int i = 0; i < 6; i++)
        {
            saved_unlocked_clothe[i] = data.player_unlocked_outfit[i];
        }

        for (int i = 0; i < 6; i++)
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
        totalgold = 10000;
        unlocked_clothe = new bool[] { true, false, false, false, false, false };
        app_open_count = new bool[] { false, false, false };
        SaveGame();
        SceneManager.LoadScene("MainMenuMindGarden");
    }

}
