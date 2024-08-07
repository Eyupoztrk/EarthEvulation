using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFormat
{
    public string FormatInt(float value)
    {
        if (value >= 1e18)
            return (value / 1e18).ToString("F2") + "E";
        else if (value >= 1e15)
            return (value / 1e15).ToString("F2") + "P";
        else if (value >= 1e12)
            return (value / 1e12).ToString("F2") + "T";
        else if (value >= 1e9)
            return (value / 1e9).ToString("F2") + "B";
        else if (value >= 1e6)
            return (value / 1e6).ToString("F2") + "M";
        else if (value >= 1e3)
            return (value / 1e3).ToString("F2") + "K";
        else
            return value.ToString("F0");
    }

}
