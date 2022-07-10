using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField, Min(0.01f)] private float _speed;
    [SerializeField, Min(1f)] private float _viewDistance;
    [SerializeField, Min(1f)] private float _lifeTime;

    private bool _seen = false;

    void Update()
    {
        if (!_seen)
        {
            float distance = Vector2.Distance(transform.position, Player.Instance.position);
            if (distance <= _viewDistance)
                _seen = true;
        }
        if (_seen)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                Player.Instance.position, _speed * Time.deltaTime);
            _lifeTime -= Time.deltaTime;

            if (_lifeTime <= 0)
                Destroy(gameObject);
        }
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _viewDistance);
    }

#endif
}
