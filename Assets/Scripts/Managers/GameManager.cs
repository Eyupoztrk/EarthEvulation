using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [HideInInspector] public StringFormat stringFormat;

    public Point point;
    public FLOAT pointAmount;
    public INTEGER increaseAmount;



    private void Awake()
    {
        instance = this;
        pointAmount.Initialize("pointAmount");
        increaseAmount.Initialize("increaseAmount");
        
        point = new Point(pointAmount.value,increaseAmount.value);
        stringFormat = new StringFormat();
    }


   
}
