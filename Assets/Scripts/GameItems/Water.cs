using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : PlanetConditionManager
{
    public FLOAT WaterValue;
    public int suitableMinWater;

    private void Start()
    {
        WaterValue.Initialize("WaterValue");
        StartCoroutine(SetElement());
    }
     public override void SetUI()
    {
        UIManager.instance.SetText(UIManager.instance.waterText, WaterValue.value.ToString() + " cm3");
    }

    public override void CalculateElement()
    {
        foreach (var item in Elements)
        {
            WaterValue.value += item.GetAmount();
        }
    }

    public override void ChechEvulation()
    {

        if ( WaterValue.value > suitableMinWater)
        {
            OnReachCondition?.Invoke();
        }
    }
}
