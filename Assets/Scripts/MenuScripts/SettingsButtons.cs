using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsButtons : MonoBehaviour
{
    public GameObject tut1;
    public GameObject tut2;
    public GameObject tut3;


    public void showTut1()
    {
        tut1.SetActive(true);
    }
    public void hideTut1()
    {
        tut1.SetActive(false);
    }
    public void showTut2()
    {
        tut2.SetActive(true);
    }
    public void hideTut2()
    {
        tut2.SetActive(false);
    }
    public void showTut3()
    {
        tut3.SetActive(true);
    }
    public void hideTut3()
    {
        tut3.SetActive(false);
    }
    public void ShowSettings()
    {
        this.gameObject.SetActive(true);
    }

    public void HideSettings()
    {
        FindObjectOfType<SettingManager>().selectLanguage();
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
