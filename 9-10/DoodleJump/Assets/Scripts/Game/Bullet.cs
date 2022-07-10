using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)] private float _beginImpulse;
    [SerializeField, Min(1)] private float _lifeTime;

    void Start()
    {
        Destroy(gameObject, _lifeTime);
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * _beginImpulse, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy _))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
