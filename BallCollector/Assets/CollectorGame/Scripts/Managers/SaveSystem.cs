using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveHighscore(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(score);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadHighscore()
    {
        string path = Application.persistentDataPath + "/save.data";
        if (!File.Exists(path))
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
        else
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
    }
}
