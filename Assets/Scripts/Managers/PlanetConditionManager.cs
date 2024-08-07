using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlanetConditionManager : MonoBehaviour
{
    public List<Element> Elements;
    public GameObject CurrentPlanet;
    public GameObject TargetPlanet;
    public Action OnReachCondition;
    public float ChangePlanetDelay;
    public bool isComplete;


    public void SetPlanet()
    {
        CurrentPlanet.SetActive(false);
        TargetPlanet.SetActive(true);
    }

    private void OnEnable()
    {
        OnReachCondition += HandleOnReachCondition;
    }


    public IEnumerator SetElement()
    {
        while (true)
        {
            SetUI();

            yield return new WaitUntil(predicate: () =>
            {
                return Elements[0].Level != 0 ? true : false;
            });

            ChechEvulation();
            CalculateElement();

            yield return new WaitForSeconds(1);
        }
    }

    public abstract void ChechEvulation();
    public abstract void CalculateElement();
    public abstract void SetUI();

    public void HandleOnReachCondition()
    {
        isComplete = true;
        SetPlanet();
    }

    private IEnumerator ChangePlanet()
    {
        CurrentPlanet.GetComponent<PlanetMovement>().isDragging = true;
        float elapsed = 0f;
        var rotationSpeed = 500f;
        var slowDownDuration = 0.4f;
        while (elapsed < slowDownDuration)
        {
            CurrentPlanet.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            rotationSpeed = Mathf.Lerp(rotationSpeed, 0f, elapsed / slowDownDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        CurrentPlanet.GetComponent<PlanetMovement>().isDragging = false;

        rotationSpeed = 0f;
        yield return new WaitForSeconds(ChangePlanetDelay);
        SetPlanet();
    }



}
