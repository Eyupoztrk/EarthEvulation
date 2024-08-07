using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BiosPoint : MonoBehaviour
{
    [Header("IN GAME")]
    public Bios bios;
    private Button button;
    public Bios RequiredBios;
    public Element RequiredElement;
    public Action OnReachPoint;
    public Action OnUnderPoint;
    public int RequiredBiosLevel;
    public int RequiredElementLevel;
    public int maxLevel;


    [Header("UI PART")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI increaseAmountText;
    [SerializeField] TextMeshProUGUI info1Text;
    [SerializeField] TextMeshProUGUI info2Text;
    [SerializeField] Slider levelSlider;
    [SerializeField] GameObject infoPanel;

    private void Start()
    {

        button = GetComponent<Button>();
        button.onClick.AddListener(() => OnButonClick());
        levelSlider.maxValue = maxLevel;
        SetUI();

        if (CheckBios(RequiredBiosLevel, RequiredElementLevel))
        {
            infoPanel.SetActive(false);
        }
        else
        {
            print(bios.name);
            StartCoroutine(CheckInfoPanel()); // listen
        }
    }

    private void OnButonClick()
    {
        if (CheckPoint(GameManager.instance.point.PointAmount) && CheckBios(RequiredBiosLevel, RequiredElementLevel))
        {
            GameManager.instance.point.DecreasePointAmount(bios.RequiredPoint);
            GameManager.instance.point.IncreaseIncreaseAmount(bios.IncreaseValue);
            bios.Level++;
            bios.RequiredPoint += bios.RequiredPoint * bios.RequiredPointCoefficient;

            SetUI();

            SetPoint(GameManager.instance.point.PointAmount);
            AudioManager.instance.PlaySound(AudioManager.instance.successSound);
        }

    }

    private void OnEnable()
    {
        OnReachPoint += HandleOnReachPoint;
        OnUnderPoint += HandleOnUnderPoint;
        // SetUI();
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
        return pointAmaount >= bios.RequiredPoint ? true : false;
    }


    public IEnumerator CheckInfoPanel()
    {
        while (true)
        {
            yield return new WaitUntil(predicate: () =>
            CheckBios(RequiredBiosLevel, RequiredElementLevel));

            infoPanel.SetActive(false);

            break;
        }

    }

    private bool CheckBios(int level1, int level2)
    {
        return RequiredBios.Level >= level1 && RequiredElement.Level >= level2;
    }

    public void SetUI()
    {
        nameText.text = bios.name;
        valueText.text = GameManager.instance.stringFormat.FormatInt(bios.RequiredPoint);
        levelText.text = "Level " + GameManager.instance.stringFormat.FormatInt(bios.Level);
        increaseAmountText.text = "+ " + GameManager.instance.stringFormat.FormatInt(bios.IncreaseValue) + " /sn";
        levelSlider.value = bios.Level;

        UIManager.instance.SetText(UIManager.instance.increaseText, GameManager.instance.stringFormat.FormatInt(GameManager.instance.point.IncreaseAmount) + " / sn");

        if (RequiredBiosLevel == 0)
        {
            info1Text.text = RequiredElementLevel.ToString() + " Level '" + RequiredElement.name + "'";
            info2Text.text = "";
        }
        else
        {
            info1Text.text = RequiredElementLevel.ToString() + " Level '" + RequiredElement.name + "'";
            info2Text.text = RequiredBiosLevel.ToString() + " Level '" + RequiredBios.name + "'";
        }
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
