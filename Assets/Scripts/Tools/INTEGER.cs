using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Integer 1", menuName = "Integer/Integer", order = 1)]

public class INTEGER : ScriptableObject
{
    public int value;
    private string _name;

    public void Initialize(string name)
    {
        _name = name;
        //value = GetSavedValue();
    }

    public void SaveValue()
    {
        PlayerPrefs.SetInt(_name, value);
    }

    private int GetSavedValue()
    {
        Debug.Log(PlayerPrefs.GetInt(_name));
        return PlayerPrefs.GetInt(_name);
    }
}
