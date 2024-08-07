using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Point point;
    [SerializeField] List<PlayerPoint> playerPoints;
    [SerializeField] List<BiosPoint> biosPoints;

    private void Start()
    {
        point = GameManager.instance.point;
        StartCoroutine(WorkContinually());
    }


    public IEnumerator WorkContinually()
    {
        var isComplete = false;
        while (true)
        {
            point.IncreasePointAmount(GameManager.instance.point.IncreaseAmount, ref isComplete);
            UIManager.instance.SetPointText();

            yield return new WaitUntil(predicate: () =>
            {
                return isComplete;
            });

            isComplete = false;

            foreach (var item in playerPoints)
            {
                item.SetPoint(point.PointAmount);
            }
            foreach (var item in biosPoints)
            {
                item.SetPoint(point.PointAmount);
            }

            yield return new WaitForSeconds(1f);

        }

    }


}
