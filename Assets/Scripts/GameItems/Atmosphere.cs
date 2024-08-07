using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atmosphere : PlanetConditionManager
{
    public FLOAT AtmosphereValue;
    public GameObject AtmosphereLayer;


    private void Start()
    {
        AtmosphereValue.Initialize("Atmosphere");
        StartCoroutine(SetElement());
    }
     public override void SetUI()
    {
        UIManager.instance.SetText(UIManager.instance.atmosphereText, AtmosphereValue.value.ToString() + " km");
    }

    public override void CalculateElement()
    {
        foreach (var item in Elements)
        {
            AtmosphereValue.value += item.GetAmount();
        }
    }

    public override void ChechEvulation()
    {
        AtmosphereLayer.transform.localScale = new Vector3(AtmosphereValue.value,AtmosphereValue.value,AtmosphereValue.value);
    }
}
