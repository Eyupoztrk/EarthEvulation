using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Organism 1", menuName = "Bios/Organism", order = 1)]

public class Bios : ScriptableObject
{
    public int Level;
    public float RequiredPoint;
    public int IncreaseValue;
    public float RequiredPointCoefficient;


}
