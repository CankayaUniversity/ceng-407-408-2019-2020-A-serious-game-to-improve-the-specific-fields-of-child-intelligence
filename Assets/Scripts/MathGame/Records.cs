using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Records
{
    public float AvgReactTime;
    public float RecordScore;
    public float TotalTrue;
    public float TotalFalse;
    public float SumOfAns;
    public float PlayerType;
    public int result;


    public void Detect_Type(Records records)
    {
        Debug.Log("PlayerType_detect func value = " + records.PlayerType);
        if (records.PlayerType < 150f)
        {
            Debug.Log("Player Type = Begginer.(Type1)");
            records.result = 1;

        }
        if (records.PlayerType >= 150f && records.PlayerType < 300f)
        {
            Debug.Log("Player Type = Intermediate.(Type2)");
            records.result = 2;
        }
        if (records.PlayerType > 300f)
        {
            Debug.Log("Player Type = Proffesional.(Type3)");
            records.result = 3;
        }
    }

}
