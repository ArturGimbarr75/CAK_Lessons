using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerHorizontalMovement : MonoBehaviour
{
    [SerializeField, Min(0)] private float _movementImpulse = 5f;
    private Rigidbody2D _rigidbody;
    private float _impulse;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _impulse = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        if (Border.Instance.LeftBorderX > transform.position.x)
        {
            pos.x = Border.Instance.RightBorderX;
            transform.position = pos;
        }
        if (Border.Instance.RightBorderX < transform.position.x)
        {
            pos.x = Border.Instance.LeftBorderX;
            transform.position = pos;
        }
    }

    void FixedUpdate()
    {
        _rigidbody.AddForce(Vector2.right * _impulse * _movementImpulse, ForceMode2D.Impulse);
    }
}
