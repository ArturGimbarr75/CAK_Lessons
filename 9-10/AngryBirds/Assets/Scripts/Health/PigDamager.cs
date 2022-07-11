using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health), typeof(Rigidbody2D))]
public class PigDamager : MonoBehaviour
{
    [SerializeField, Range(1f, 100)] private float _velocityMultiplier;
    private Rigidbody2D _rigidbody;
    private Health _health;
    private float _recivedDamage = 0;

    void LateUpdate()
    {
        _health ??= GetComponent<Health>();
        _health.Hit(_recivedDamage);
        _recivedDamage = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody ??= GetComponent<Rigidbody2D>();
        _health ??= GetComponent<Health>();

        float hit = _rigidbody.velocity.magnitude * _velocityMultiplier;
        _recivedDamage = hit;

        if (collision.transform.TryGetComponent(out PigDamager pigDamager))
            pigDamager.Hit(_recivedDamage);
    }

    public void Hit(float damage) => _recivedDamage = Mathf.Max(damage, _recivedDamage);
}
