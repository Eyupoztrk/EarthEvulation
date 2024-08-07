using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] PlanetConditionManager planetConditionManager;

    private void OnEnable() {
      //  print(planetConditionManager.atmosphere);
    }
}
