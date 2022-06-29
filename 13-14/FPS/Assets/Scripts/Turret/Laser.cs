using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{

    [SerializeField, Min(0)] private float _maxLaserLength = 100f;

    private LineRenderer _lineRenderer;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
    }

    void OnEnable()
    {
        _lineRenderer.enabled = true;
    }

    void OnDisable()
    {
        _lineRenderer.enabled = false;
    }

    void Update()
    {
        _lineRenderer.SetPosition(0, transform.position);
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _maxLaserLength))
            _lineRenderer.SetPosition(1, hit.point);
        else
            _lineRenderer.SetPosition(1, transform.position + transform.forward * _maxLaserLength);
    }
}
