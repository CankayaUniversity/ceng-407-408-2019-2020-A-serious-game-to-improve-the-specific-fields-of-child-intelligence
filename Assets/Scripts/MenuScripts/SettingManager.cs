using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class SettingManager : MonoBehaviour
{
    public Slider soundVolumeSlider;
    public Slider musicVolumeSlider;
    public Button applyButton;

    public AudioSource soundSource;
    public AudioSource musicSource;
    public GameSettings gameSettings;

    void OnEnable()
    {

        gameSettings = new GameSettings();


       
        soundVolumeSlider.onValueChanged.AddListener(delegate { OnSoundVolumeChange(); });
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnMusicVolumeChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

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
}
    

