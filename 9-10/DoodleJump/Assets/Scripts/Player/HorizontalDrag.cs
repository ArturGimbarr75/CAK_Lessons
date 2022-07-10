using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HorizontalDrag : MonoBehaviour
{
    [SerializeField, Range(0.01f, 1)] private float _drag = 0.7f;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = _rigidbody.velocity;
        velocity.x *= _drag;
        _rigidbody.velocity = velocity;
    }
}
