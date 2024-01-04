using System.IO;
using UnityEngine;

public static class SaveGameManager
{
    public static SaveData CurrentSaveData = new SaveData();

    public const string SaveDirectory = "/SaveData/"; 
    public const string FileName = "SaveGame.sav"; 

    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + SaveDirectory; 

        if (!Directory.Exists(dir)) // if directory does not already exist
        {
            Directory.CreateDirectory(dir); // make folder
        }

        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FileName, json);

        GUIUtility.systemCopyBuffer = dir;

        return true;
    }

    public static void LoadGame() // Function to load game
    {
        string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
        SaveData tempData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json); // turn string to custom class save data
        }
        else
        {
            Debug.Log("Save file does not exist");
        }

        CurrentSaveData = tempData;

    }

    public static void NewGame() // Function to create new game
    {
        SaveGame(); 
    }

}

