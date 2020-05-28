using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeMaster : MonoBehaviour
{
    DateTime currentDate;
    DateTime olddate;

    public string saveLocation;
    public static TimeMaster instance;
    
    void Awake()
    {
        instance = this;
        saveLocation = "lastSavedData";
    }

    public float CheckDate()
    {
        currentDate = System.DateTime.Now;
        string TempString = PlayerPrefs.GetString(saveLocation, "1");
        long tempLong = Convert.ToInt64(TempString);

        olddate = DateTime.FromBinary(tempLong);
        print("Old Date : " + olddate);

        TimeSpan difference = currentDate.Subtract(olddate);
        print("Diffrence: " + difference);
        return (float)difference.TotalSeconds;
    }

    public void SaveDate()
    {
        PlayerPrefs.SetString(saveLocation, System.DateTime.Now.ToBinary().ToString());
        print("Saving this date to player prefs: " + System.DateTime.Now);
    }
}
