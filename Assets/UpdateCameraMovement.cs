using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 1f;
    float moveSpeed = 10f;
    // public RectTransform crosshair;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX);
        transform.Rotate(Vector3.left, mouseY);

        // Debug.Log("mmm : " + Input.mousePosition);

        // Update crosshair position
        // Vector2 crosshairPosition = Input.mousePosition;
        // crosshair.anchoredPosition = crosshairPosition;

        float xValue = Time.deltaTime * Input.GetAxis("Horizontal") * moveSpeed;
        float zValue = Time.deltaTime * Input.GetAxis("Vertical") * moveSpeed;


        transform.Translate(xValue, 0, zValue);
    }
}
