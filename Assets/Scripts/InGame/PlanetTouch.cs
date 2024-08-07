using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlanetTouch : MonoBehaviour
{
    private Animator animator;
    public INTEGER ClickCounter;
    StringFormat stringFormat;

    private void Start()
    {
        ClickCounter.Initialize("ClickCounter");
        stringFormat = new StringFormat();
        animator = GetComponent<Animator>();
    }
    private void OnMouseDown()
    {


        animator.SetBool("isClick", true);
        LogManager.instance.SetLog("+ "+stringFormat.FormatInt(ClickCounter.value));


        GameManager.instance.point.IncreaseIncreaseAmount(ClickCounter.value);
        UIManager.instance.SetText(UIManager.instance.increaseText, GameManager.instance.point.FormatInt(GameManager.instance.point.IncreaseAmount) + " / sn");
        ClickCounter.value++;
        AudioManager.instance.PlaySound(AudioManager.instance.clickSound);


    }

    private void OnMouseUp()
    {
        animator.SetBool("isClick", false);
    }



}
