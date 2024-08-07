using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;

public class LogManager : MonoBehaviour
{
    public static LogManager instance;
    private void Awake()
    {
        instance = this;
    }
    public List<GameObject> Logs;
    public float MaxX, MinX, MaxY, MinY;

    public void SetLog(string text)
    {
        var log = GetLog();
        log.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        float randomX = Random.Range(MinX, MaxX);
        float randomY = Random.Range(MinY, MaxY);
        Vector2 randomPosition = new Vector2(randomX, randomY);
        log.GetComponent<RectTransform>().anchoredPosition = randomPosition;

        StartCoroutine(SetActiveFalse(log));
    }

    private GameObject GetLog()
    {
        foreach (var obj in Logs)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;

            }
        }

        return null;
    }

    private IEnumerator SetActiveFalse(GameObject log)
    {
        yield return new WaitForSeconds(0.8f);
        log.SetActive(false);
    }
}
