using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start() {
        OpenPanel(0);
    }

    [SerializeField] private GameObject mainPanel;
    [SerializeField] private float mainPanelSpeed;
    [SerializeField] private CameraMovement cameraMovement;
    public bool isOpen;

    [Header("Panels")]
    [SerializeField] private List<GameObject> panels;
    [SerializeField] private List<GameObject> panelButons;

    [Header("Score UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI increaseText;


    [Header("Element UI")]
    public TextMeshProUGUI tempText;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI oxygenText;
    public TextMeshProUGUI waterText;
    public TextMeshProUGUI atmosphereText;

    [Header("TASK UI")]
    public List<GameTask> tasks;



    public void OpenMainPanel()
    {

        StartCoroutine(OpenMainPanelIterator());
    }
    public IEnumerator OpenMainPanelIterator()
    {
        if (!isOpen)
        {
            StartCoroutine(cameraMovement.CamMovement());
            while (true)
            {
                yield return null;
                mainPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(mainPanel.GetComponent<RectTransform>().anchoredPosition, new Vector2(0, -900), mainPanelSpeed);
                if (mainPanel.GetComponent<RectTransform>().anchoredPosition.y >= -905)
                {
                    isOpen = true;
                    break;
                }

            }

        }
        else
        {
            StartCoroutine(cameraMovement.CamMovement2());
            while (true)
            {
                yield return null;
                mainPanel.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(mainPanel.GetComponent<RectTransform>().anchoredPosition, new Vector2(0, -1500), mainPanelSpeed);
                if (mainPanel.GetComponent<RectTransform>().anchoredPosition.y <= -1489)
                {
                    isOpen = false;
                    break;
                }

            }
        }


    }

    public void OpenPanel(int id)
    {
        for (int i = 0; i < panels.Count; i++)
        {
            if(id == i)
            {
                //panels[i].SetActive(true);
                panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(0,panels[i].GetComponent<RectTransform>().anchoredPosition.y);
                panelButons[i].GetComponent<Image>().color = Color.white;
            }
            else
            {
                //panels[i].SetActive(false);
                panels[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(1500,panels[i].GetComponent<RectTransform>().anchoredPosition.y);
                panelButons[i].GetComponent<Image>().color = Color.gray;
            }

            if(id == 2)
            {
                SetTask();
            }
        }
    }

    private void SetTask()
    {
        foreach (var item in tasks)
        {
            item.SetTask();
        }
    }

    public void SetText(TextMeshProUGUI text, string value)
    {
        text.text = value;
    }

    public void SetPointText()
    {
        scoreText.text = GameManager.instance.point.FormatInt(GameManager.instance.point.PointAmount);

    }
}
