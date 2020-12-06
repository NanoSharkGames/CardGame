﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveGameData(GameManager gameManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/savedata.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(gameManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/savedata.txt";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
