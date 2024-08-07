using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point
{
    public float PointAmount { get; private set; }
    public int IncreaseAmount { get; private set; }
    

    public Point(float PointAmount, int IncreaseAmount)
    {
        this.PointAmount = PointAmount;
        this.IncreaseAmount = IncreaseAmount;
    }


    public void IncreasePointAmount(int amount, ref bool isComplete)
    {
        PointAmount += amount;
        isComplete = true;
        GameManager.instance.pointAmount.value = PointAmount;
    }
    public void DecreasePointAmount(float amount)
    {
        PointAmount -= amount;
        if (PointAmount <= 0)
            PointAmount = 0;
        GameManager.instance.pointAmount.value = PointAmount;
    }

    public void IncreaseIncreaseAmount(int amount)
    {
        IncreaseAmount += amount;
        GameManager.instance.increaseAmount.value = IncreaseAmount;
    }



    public string FormatInt(float value)
    {
        return GameManager.instance.stringFormat.FormatInt(value);
    }





}
