using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    private Vector3 lastMousePosition;
    public bool isDragging = false;
    [SerializeField] private float manuelRotationSpeed = 5f;
    [SerializeField] private float automaticRotationSpeed = 5f;

    private void Start()
    {
        lastMousePosition = Vector3.up;
        StartCoroutine(AutomaticRotate());
    }


    private void OnMouseDrag()
    {
        isDragging = true;
        Vector3 deltaMousePosition = GetMousePos();
        float rotationX = deltaMousePosition.y * manuelRotationSpeed * Time.deltaTime;
        float rotationY = -deltaMousePosition.x * manuelRotationSpeed * Time.deltaTime;

        // X ve Y eksenlerinde döndür
        transform.Rotate(Vector3.up, rotationY, Space.World);
        transform.Rotate(Vector3.right, rotationX, Space.World);

        // Fare pozisyonunu güncelle
         lastMousePosition = Input.mousePosition;

    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector2 GetMousePos()
    {
        var mousePos = Input.mousePosition - lastMousePosition;
        return mousePos;
    }

    private IEnumerator AutomaticRotate()
    {
        while (true)
        {
           yield return new WaitUntil(predicate: () =>
           {
            return !isDragging;
           });

          transform.Rotate(Vector3.up * automaticRotationSpeed * Time.deltaTime);
        }

    }



}
