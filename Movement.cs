using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float maxUp;
    [SerializeField] private float minUp;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float xRotation;

    private Transform MainCamera;


    public void Update()
    {
        GetAxis();
        SetMouseRotation();
    }

    private void GetAxis()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
    }

    private void SetMouseRotation()
    {
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        xRotation = Mathf.Clamp(xRotation, (maxUp * -1), (minUp * -1));
        MainCamera.Rotate(Vector3.up * mouseX);
        mouseX = 0;
        mouseY = 0;
    }
}
