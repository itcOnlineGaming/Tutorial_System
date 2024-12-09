using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoolDictionary
{
    [SerializeField]
    private List<BoolEntry> boolEntries = new List<BoolEntry>();

    public void SetValue(string key, bool value) //set values to be saved later
    {
        var existingEntry = boolEntries.Find(entry => entry.Key == key);
        if (existingEntry != null)
        {
            existingEntry.Value = value;
        }
        else
        {
            boolEntries.Add(new BoolEntry(key, value));
        }
    }

    public bool GetValue(string key) //finds boolean based on name
    {
        var entry = boolEntries.Find(e => e.Key == key);
        return entry != null && entry.Value;
    }

    public bool ContainsKey(string key)
    {
        return boolEntries.Exists(e => e.Key == key);
    }
}

[System.Serializable]
public class BoolEntry
{
    public string Key;
    public bool Value;

    public BoolEntry(string key, bool value)
    {
        Key = key;
        Value = value;
    }
}