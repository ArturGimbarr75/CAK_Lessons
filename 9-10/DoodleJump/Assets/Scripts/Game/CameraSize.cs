using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        _camera ??= GetComponent<Camera>();
        float aspect = (Border.Instance?.Width ?? 20f / 2f) / (_camera.orthographicSize * _camera.aspect);
        _camera.orthographicSize *= aspect * 0.5f;
    }

#if UNITY_EDITOR

    void OnValidate()
    {
        ChangeSize();
    }

#endif
}
