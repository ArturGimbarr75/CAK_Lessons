using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HorizontalDrag : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _dragFactor = 0.7f;
    [SerializeField] private bool _useDragInAir;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!_useDragInAir)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x *= 1.0f - _dragFactor;
        velocity.z *= 1.0f - _dragFactor;
        _rigidbody.velocity = velocity;
    }
}
