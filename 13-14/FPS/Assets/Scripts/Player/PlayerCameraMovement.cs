using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMovement : MonoBehaviour
{
    [SerializeField, Range(30, 179)] private float _verticalAngle;
    [SerializeField, Min(0)] private float _turnSpeed = 0.2f;
    [SerializeField] private bool _verticalInvertion = false;
    [SerializeField] private Camera _playerCamera;

    private float _xAxis = 0f; 

    void Update()
    {
        Vector2 rawLookVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 lookVector = new Vector2(rawLookVector.x * _turnSpeed, rawLookVector.y * _turnSpeed);

        _xAxis = Mathf.Clamp(_xAxis + (_verticalInvertion ? lookVector.y : -lookVector.y), -_verticalAngle / 2, _verticalAngle / 2);
        transform.Rotate(Vector3.up * lookVector.x);

        _playerCamera.transform.localRotation = Quaternion.Euler(Vector3.right * _xAxis);
    }
}
