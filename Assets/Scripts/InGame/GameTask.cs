using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameTask : MonoBehaviour
{
    public string MainString;
    public RawImage background;
    public TextMeshProUGUI MainStringText;
    public RawImage completeImage;
    public RawImage inCompleteImage;
    public PlanetConditionManager planetConditionManager;

    private void Start() {
    }

    public void SetTask()
    {
        if(planetConditionManager.isComplete) // eğer görev tamamlandıysa
        {
            CompleteTask();
        }
        else
        {
            InCompleteTask();
        }
    }

    private void CompleteTask()
    {
        background.color = Color.green;
        MainStringText.text = MainString;
        completeImage.gameObject.SetActive(true);
        inCompleteImage.gameObject.SetActive(false);
    }

    private void InCompleteTask()
    {
        background.color = Color.red;
        MainStringText.text = MainString;
        completeImage.gameObject.SetActive(false);
        inCompleteImage.gameObject.SetActive(true);
    }

}
