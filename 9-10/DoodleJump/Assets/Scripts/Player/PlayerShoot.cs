using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField, Min(0)] private float _cooldownTime;
    [SerializeField, Min(0)] private float _verticalOffset;

    private bool _canShoot = true;
    
    void Update()
    {
        if (_canShoot && Input.GetKeyDown(KeyCode.Space))
        {
            _canShoot = false;
            Invoke(nameof(Cooldown), _cooldownTime);
            Instantiate(_bulletPrefab).transform.position = transform.position
                + Vector3.up * _verticalOffset;
        }
    }

    void Cooldown() => _canShoot = true;
}
