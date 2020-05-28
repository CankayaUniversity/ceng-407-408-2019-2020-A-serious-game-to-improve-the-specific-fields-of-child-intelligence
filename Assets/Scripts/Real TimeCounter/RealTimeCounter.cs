using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTimeCounter : MonoBehaviour
{
    public float timer;

    void Start()
    {
        timer = 86400; //Counting one day in terms of seconds
        timer -= TimeMaster.instance.CheckDate();
        if (!AllVar.game_accesable)
        {
            timer = 25;
            timer -= TimeMaster.instance.CheckDate();
        }
    }

   
    void Update()
    {
        timer -= Time.deltaTime;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,100,50), "Save Time"))
        {
            ResetClock();
        }

        if (GUI.Button(new Rect(10, 150, 100, 50), "CheckTime"))
        {
            print(60 - TimeMaster.instance.CheckDate() + "in real seconds has passed");
            if (timer < 100 )
            {
                Debug.Log("Your game session ended");
            }
        }

        GUI.Label(new Rect(10, 150, 100, 50), timer.ToString());
    }

    void ResetClock()
    {
        TimeMaster.instance.SaveDate();
        timer = 1000;
        timer -= TimeMaster.instance.CheckDate();
    }
}
