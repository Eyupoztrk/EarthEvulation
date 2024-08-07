using UnityEngine;

[CreateAssetMenu(fileName = "float 1", menuName = "Float/float", order = 1)]
public class FLOAT : ScriptableObject
{
    public float value;
    private string _name;

    public void Initialize(string name)
    {
        _name = name;
       // value = GetSavedValue();
    }

    public void SaveValue()
    {
        PlayerPrefs.SetFloat(_name, value);
    }

    private float GetSavedValue()
    {
        Debug.Log(PlayerPrefs.GetFloat(_name));
        return PlayerPrefs.GetFloat(_name);
    }
}