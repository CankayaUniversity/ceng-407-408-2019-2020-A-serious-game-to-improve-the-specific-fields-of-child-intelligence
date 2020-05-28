using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourDetect : MonoBehaviour
{
    int hour = System.DateTime.Now.Hour;
    int minute = System.DateTime.Now.Minute;
    int day=0;
    public static bool resetflag = false;

    void Awake()
    {
        day = PlayerPrefs.GetInt("Gün");
        Debug.Log(day);
        

        if (day != System.DateTime.Now.Day)
        {
            if (hour >= 12 && minute >= 0)
            {
                day = System.DateTime.Now.Day;
                PlayerPrefs.SetInt("Gün", day);
                PlayerPrefs.SetInt("Rutin", 0);
                Debug.Log("Oyuna girebilirsin");
                resetflag = true;
            }
        }
    }    
}
