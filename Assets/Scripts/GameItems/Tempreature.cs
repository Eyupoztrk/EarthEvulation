using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Tempreature : PlanetConditionManager
{
    public FLOAT TempreatureValue;
    public int suitableMinTemp;

    private void Start()
    {
        TempreatureValue.Initialize("TempreatureValue");
        StartCoroutine(SetElement());
    }
    public override void SetUI()
    {
        UIManager.instance.SetText(UIManager.instance.tempText, TempreatureValue.value.ToString() + " C");
    }

    public override void CalculateElement()
    {
        foreach (var item in Elements)
        {
            TempreatureValue.value -= item.GetAmount();
        }
    }

    public override void ChechEvulation()
    {

        if (TempreatureValue.value <= suitableMinTemp)
        {
            OnReachCondition?.Invoke();
        }
    }


}
