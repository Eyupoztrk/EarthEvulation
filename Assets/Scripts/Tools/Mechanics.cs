using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mechanics : MonoBehaviour
{
    public static Mechanics instance;
    private void Awake() {
        instance = this;
    }
    float startTime = 0f;

    public Vector3 LerpMechanics(Vector3 pos1, Vector3 pos2, float speed, ref bool isComplete)
    {
            startTime += Time.deltaTime;
            float t = startTime * speed;
            t = Mathf.Clamp01(t);
            print(startTime);
            print(t);

            pos1 = Vector3.Lerp(pos1, pos2, speed);

            if (t >= 1.0f)
            {
                Debug.Log("Lerp işlemi tamamlandı!");
                isComplete = true;
                
            }

        

        return pos1;
    }
}
