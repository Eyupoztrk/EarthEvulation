using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Element 1", menuName = "Elements/Element", order = 1)]
public class Element : ScriptableObject
{
    public float RequiredPoint; // burayı açmak için gereken puan
    public int IncreaseValue; // saniyede arttırdığı miktar
    public int Level; // element seviyesi
    public float RequiredPointCoefficient; // gereken puanın artışını belirleyen katsayı
    public int ElementPower; // Elementi artırıp / azaltacak güç

    public float GetAmount()
    {
        var baseAmount = (float)(Level * ElementPower) / 100;
        return baseAmount;   
    }

}
