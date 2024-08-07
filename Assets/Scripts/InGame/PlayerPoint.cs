using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPoint : MonoBehaviour
{

    [Header("IN GAME PART")]
    public Action OnReachPoint;
    public Action OnUnderPoint;
    private Button button;
    public Element element;

    [Header("UI PART")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI increaseAmountText;


    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButonClick());
        SetUI();
    }

    private void OnButonClick()
    {
        if (CheckPoint(GameManager.instance.point.PointAmount))
        {
            GameManager.instance.point.DecreasePointAmount(element.RequiredPoint);
            GameManager.instance.point.IncreaseIncreaseAmount(element.IncreaseValue);
            element.Level++;
            element.RequiredPoint += element.RequiredPoint * element.RequiredPointCoefficient;
            SetUI();

            SetPoint(GameManager.instance.point.PointAmount);
            AudioManager.instance.PlaySound(AudioManager.instance.successSound);
        }

    }

    private void OnEnable()
    {
        OnReachPoint += HandleOnReachPoint;
        OnUnderPoint += HandleOnUnderPoint;
    }
    private void OnDisable()
    {
        OnReachPoint -= HandleOnReachPoint;
        OnUnderPoint -= HandleOnUnderPoint;
    }
    public void SetPoint(float pointAmaount)
    {
        if (CheckPoint(pointAmaount))
        {
            OnReachPoint?.Invoke();
        }
        else
        {
            OnUnderPoint?.Invoke();
        }

    }
    private bool CheckPoint(float pointAmaount)
    {
        return pointAmaount >= element.RequiredPoint ? true : false;
    }

    public void SetUI()
    {
        nameText.text = element.name;
        valueText.text = GameManager.instance.stringFormat.FormatInt(element.RequiredPoint);
        levelText.text = "Level " + GameManager.instance.stringFormat.FormatInt(element.Level);
        increaseAmountText.text = "+ "+GameManager.instance.stringFormat.FormatInt(element.IncreaseValue) + " /sn";

        UIManager.instance.SetText(UIManager.instance.increaseText, GameManager.instance.stringFormat.FormatInt(GameManager.instance.point.IncreaseAmount) + " / sn");
    }

    protected virtual void HandleOnReachPoint()
    {
        button.interactable = true;
    }
    protected virtual void HandleOnUnderPoint()
    {
        button.interactable = false;
    }
}
