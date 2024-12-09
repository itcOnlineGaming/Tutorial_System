using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class BoolSaveSystem
{
    private static string filePath;

    private static string FilePath
    {
        get
        {
            if (filePath == null)
            {
                filePath = Application.persistentDataPath + "/TutorialPopUps.json"; //sets file path into your local app data folder
            }
            return filePath;
        }
    }
    public static void SaveBool(string boolName, bool value)
    {
        BoolDictionary boolData = LoadAllBools() ?? new BoolDictionary();
        boolData.SetValue(boolName, value); //sets value to dictionary

        string jsonData = JsonUtility.ToJson(boolData); //saves data
        Debug.Log("Saving data: " + jsonData);

        File.WriteAllText(FilePath, jsonData); //writes
    }
    public static bool LoadBool(string boolName)
    {
        BoolDictionary boolData = LoadAllBools();

        if (boolData != null && boolData.ContainsKey(boolName))
        {
            return boolData.GetValue(boolName); //gets value based on string key
        }

        return false;
    }

    private static BoolDictionary LoadAllBools()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = File.ReadAllText(FilePath);

            if (string.IsNullOrEmpty(jsonData))
            {
                Debug.LogWarning("The file is empty. Returning default BoolDictionary.");
                return new BoolDictionary();
            }

            try
            {
                return JsonUtility.FromJson<BoolDictionary>(jsonData);
            }
            catch (Exception e)
            {
                Debug.LogError("Failed to parse JSON: " + e.Message);
                return new BoolDictionary();
            }
        }
        else
        {
            Debug.LogWarning("No File Present. Returning new BoolDictionary.");
            return new BoolDictionary();
        }
    }
}
