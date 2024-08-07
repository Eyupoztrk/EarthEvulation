using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : PlanetConditionManager
{
    public FLOAT PressureValue;
    public int suitableMinPressure;



    private void Start()
    {
        PressureValue.Initialize("PressureValue");
        StartCoroutine(SetElement());
    }
    public override void SetUI()
    {
        UIManager.instance.SetText(UIManager.instance.pressureText, PressureValue.value.ToString() + " Pa");
    }
    public override void CalculateElement()
    {
        foreach (var item in Elements)
        {
            PressureValue.value += item.GetAmount();
        }
    }

    public override void ChechEvulation()
    {
        if (PressureValue.value > suitableMinPressure)
        {
            OnReachCondition?.Invoke();
        }
    }
}
