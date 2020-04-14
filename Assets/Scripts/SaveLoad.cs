using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.IO;

public static class SaveLoad
{
    public static void SaveData(AllVar allvar)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gamedata.mind";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData playerdata = new PlayerData(allvar);
        formatter.Serialize(stream, playerdata);
        stream.Close();

    }

    public static PlayerData LoadData()
    {

        string path = Application.persistentDataPath + "/gamedata.mind";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerdata = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return playerdata;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
