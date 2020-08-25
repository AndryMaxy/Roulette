using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveManager
{
    public static bool isLoadData = false;
    private const string PLAYER_PATH = "player.kek";
    private const string HISTORY_PATH = "history.kek";

    private static void SaveData(string filePath, object classs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, filePath);
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, classs);
        stream.Close();
    }

    private static T LoadData<T>(string filePath)
    {
        string path = Path.Combine(Application.persistentDataPath, filePath);

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            T t = (T)formatter.Deserialize(stream);
            stream.Close();
            return t;
        }
        else
        {
            return default;
        }

    }

    public static Player LoadPlayerData() 
    {
        return LoadData<Player>(PLAYER_PATH);
    }

    public static void SavePlayerData(Player player)
    {
        SaveData(PLAYER_PATH, player);
    }

    public static History LoadHistoryData()
    {
        return LoadData<History>(HISTORY_PATH);
    }

    public static void SaveHistoryData(History history)
    {
        SaveData(HISTORY_PATH, history);
    }
}