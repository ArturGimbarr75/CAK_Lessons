using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float _jumpHeight;
    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource;
    private float _jumpForce;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _jumpForce = Mathf.Sqrt(_jumpHeight * -2 * (Physics2D.gravity.y * _rigidbody.gravityScale));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out PlatformColliderController _))
        { 
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _audioSource.Play();
        }
    }
}
