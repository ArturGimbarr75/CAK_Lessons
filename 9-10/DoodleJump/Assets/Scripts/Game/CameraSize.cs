using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraSize : MonoBehaviour
{
    [SerializeField] private float _borderSize;

    private Camera _camera;

    void Start()
    {
        ChangeSize();
    }

    private void ChangeSize()
    {
        _camera ??= GetComponent<Camera>();
        float aspect = (Border.Instance?.Width ?? _borderSize / 2f) / (_camera.orthographicSize * _camera.aspect);
        _camera.orthographicSize *= aspect * 0.5f;
    }

#if UNITY_EDITOR

    void OnValidate()
    {
        ChangeSize();
    }

#endif
}
