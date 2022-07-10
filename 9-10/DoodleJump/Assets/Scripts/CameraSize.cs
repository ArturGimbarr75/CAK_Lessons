using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
    private Camera _camera;

    void Awake()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        _camera ??= GetComponent<Camera>();
        float aspect = (Border.Instance.Width / 2) / (_camera.orthographicSize * _camera.aspect);
        _camera.orthographicSize *= aspect;
    }

#if UNITY_EDITOR

    void OnValidate()
    {
        ChangeSize();
    }

#endif
}
