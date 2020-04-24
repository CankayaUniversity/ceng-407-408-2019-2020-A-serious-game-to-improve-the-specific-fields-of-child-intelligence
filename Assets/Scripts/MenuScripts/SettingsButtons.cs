using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    

    public void ShowSettings()
    {
        this.gameObject.SetActive(true);
    }

    public void HideSettings()
    {
        this.gameObject.SetActive(false);
    }  

    void Start()
    {
        
        
    }
    
    //GameObject[] settingsObjects;
    
    // void Start()
    //{
    //    settingsObjects = GameObject.FindGameObjectsWithTag("Settings");
    //    hideSettings();
    //}
    
    //public void hideSettings()
    //{
    //    foreach (GameObject g in settingsObjects)
    //    {
            
    //        g.SetActive(false);

    //    }
    //}
    //public void Settings()
    //{
    //    showSettings();
    //}
    //public void showSettings()
    //{
    //    foreach (GameObject g in settingsObjects)
    //    {
    //        g.SetActive(true);

    //    }
    //}

    //public void apply()
    //{
    //    hideSettings();
    //}
    //public void ToWardrobe()
    //{
    //        SceneManager.LoadScene("Wardrobe");
    //}

    //public void ToRoutine()
    //{
    //    SceneManager.LoadScene("MiddleMatters");
        
    //}

    //public void ToSelectGame()
    //{
    //    Debug.Log("Select Game Mode !");
    //}
}
