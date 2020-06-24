using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Honeti;
public class SettingManager : MonoBehaviour
{
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;
    public Button applyButton;
    public Scrollbar languageScroll;
    public AudioSource soundSource;
    public AudioSource musicSource;
    public GameSettings gameSettings;
    public int language;
    
    private void Start()
    {
        selectLanguage();
    }
    void OnEnable()
    {

        gameSettings = new GameSettings();


       
        soundVolumeSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });
     
        //languageDropdown.onValueChanged.AddListener(delegate {selectLanguage(); });
        //LoadSettings();
    }

   
    public void OnSoundVolumeChange()
    {
        soundSource.volume = gameSettings.soundVolume = soundVolumeSlider.value;
    }
    public void OnMusicVolumeChange()
    {
        musicSource.volume = gameSettings.musicVolume = musicVolumeSlider.value;
    }
    public void OnApplyButtonClick()
    {
        selectLanguage();
        SaveSettings();
       
    }
    
    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }
    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));
        soundVolumeSlider.value = gameSettings.soundVolume;
        musicVolumeSlider.value = gameSettings.musicVolume;



    }
    public void selectLanguage()
    {
        
        if (languageScroll.value==0)
        {
            Debug.Log("English");
            language = 0;
            FindObjectOfType<I18N>().setLanguage("0");
        }
        else if (languageScroll.value==1)
        {
            Debug.Log("Türkçe");
            language = 1;
            FindObjectOfType<I18N>().setLanguage("1");

            //  FindObjectOfType<I18n>();
        }

    }
}
    

