using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public float speed;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           StartCoroutine(CamMovement());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            StartCoroutine(CamMovement2());
        }
    }


    public void Deneme()
    {
        var isComplete = false;
        while (!isComplete)
        {
            transform.position =  Mechanics.instance.LerpMechanics(transform.position,new Vector3(0, -1, -10), speed, ref isComplete);
        }
        
    }


    public IEnumerator CamMovement()
    {
        var startTime =0f;
        while (true)
        {
            yield return null;
            startTime+= Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, -1, -10), speed);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4, speed);
            if(cam.orthographicSize >= 3.8f)
            break;
        }

    }

     public IEnumerator CamMovement2()
    {
        while (true)
        {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, -10), speed);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speed);
            if(cam.orthographicSize <= 3.1f)
            break;
        }

    }
}
