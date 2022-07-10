using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    [SerializeField, Min(0)] private float _additionalHeight;
    private float _impulse;
    private Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = Player.Instance.GetComponent<Rigidbody2D>();
        _impulse = Mathf.Sqrt(_additionalHeight * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == Player.Instance)
            _rigidbody.AddForce(Vector2.up * _impulse, ForceMode2D.Impulse);
    }
}
