using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlatformColliderController : MonoBehaviour
{
    private Collider2D _collider;

    private const float OFFSET = 0.1f;

    void Start() => _collider = GetComponent<Collider2D>();

    void Update()
    {
        if (Player.Instance.position.y > transform.position.y + OFFSET)
            _collider.enabled = true;
        else if (Player.Instance.position.y < transform.position.y)
            _collider.enabled = false;
    }
}
