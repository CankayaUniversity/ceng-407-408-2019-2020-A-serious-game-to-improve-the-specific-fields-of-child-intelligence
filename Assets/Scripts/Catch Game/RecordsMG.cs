using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class RecordsMG
{
    public float AvgReactTime;
    public float RecordScore;
    public float TotalTrue;
    public float TotalFalse;
    public float PlayerType;
    public int result;

    public void PushRecords(RecordsMG newrecords, RecordsMG oldrecords)
    {
        newrecords.TotalFalse = Euclidean_Distance(oldrecords.TotalFalse, newrecords.TotalFalse);
        newrecords.TotalTrue = Euclidean_Distance(oldrecords.TotalTrue, newrecords.TotalTrue);
        newrecords.AvgReactTime = Euclidean_Distance(oldrecords.AvgReactTime, newrecords.AvgReactTime);
        newrecords.RecordScore = Euclidean_Distance(oldrecords.RecordScore, newrecords.RecordScore);
        newrecords.PlayerType = (newrecords.TotalFalse + newrecords.TotalTrue + newrecords.AvgReactTime + newrecords.RecordScore) / 4f;
        newrecords.PlayerType = Euclidean_Distance(oldrecords.PlayerType, newrecords.PlayerType);
        newrecords.Detect_Type(newrecords);

        Debug.Log(Application.persistentDataPath);
        Debug.Log("Total false = " + newrecords.TotalFalse);
        Debug.Log("Total true = " + newrecords.TotalTrue);
        Debug.Log("Total AvgReactTime = " + newrecords.AvgReactTime);
        Debug.Log("RecordScore = " + newrecords.RecordScore);
        Debug.Log("PlayerType = " + newrecords.PlayerType);

        string path = "/PlayerRecordsMG.json";
        string jsonData = JsonUtility.ToJson(newrecords, true);
        File.WriteAllText(Application.persistentDataPath + path, jsonData);


    }
    public void Detect_Type(RecordsMG records)
    {
        Debug.Log("PlayerType_detect func value = " + records.PlayerType);
        if (records.PlayerType < 50f)
        {
            Debug.Log("Player Type = Begginer.(Type1)");
            records.result = 1;

        }
        if (records.PlayerType >= 50f && records.PlayerType < 63f)
        {
            Debug.Log("Player Type = Intermediate.(Type2)");
            records.result = 2;
        }
        if (records.PlayerType > 63f)
        {
            Debug.Log("Player Type = Proffesional.(Type3)");
            records.result = 3;
        }
    }

    public static float Euclidean_Distance(float x1, float x2)
    {
        return Mathf.Sqrt((x1 - x2) * (x1 - x2));
    }

}
