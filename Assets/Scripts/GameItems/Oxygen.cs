using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : PlanetConditionManager
{
    public FLOAT OxygenValue;
    public int suitableMinOxygen;

    private void Start()
    {
        OxygenValue.Initialize("OxygenValue");
        StartCoroutine(SetElement());
    }

    public override void SetUI()
    {
        UIManager.instance.SetText(UIManager.instance.oxygenText, OxygenValue.value.ToString() + " ppm");
    }

    public override void CalculateElement()
    {
        foreach (var item in Elements)
        {
            OxygenValue.value += item.GetAmount();
        }
    }

    public override void ChechEvulation()
    {
        if (OxygenValue.value > suitableMinOxygen)
        {
            OnReachCondition?.Invoke();
        }
    }


}
