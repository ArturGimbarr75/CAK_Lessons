using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject[] _platformPrefabs;
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject _coinPrefab;

    [Header("Params")]
    [SerializeField, Range(0, 20)] private float _minYGenerationRange;
    [SerializeField, Range(0, 20)] private float _maxYGenerationRange;
    [SerializeField, Range(5, 50)] private float _spawnDistance;
    [SerializeField, Range(0, 100)] private float _coinCreationProbability;
    [SerializeField, Range(0, 100)] private float _enemyCreationProbability;
    [SerializeField, Range(0, 10)] private float _enemyCreationYPosRange;

    private float _currentHeight;
    
    void Start()
    {
        _currentHeight = transform.position.y;
    }
    
    void Update()
    {
        if (_currentHeight - Player.Instance.position.y < _spawnDistance)
        {
            GameObject temp = Instantiate(_platformPrefabs[Random.Range(0, _platformPrefabs.Length)]);
            temp.transform.position = new Vector2(Border.Instance.GetRandomX(),
                _currentHeight + Random.Range(_minYGenerationRange, _maxYGenerationRange));
            temp.transform.parent = transform;
            _currentHeight = temp.transform.position.y;

            if (Random.Range(0, 100) < _enemyCreationProbability && _enemyPrefabs.Length > 0)
            {
                GameObject enemy = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)]);
                enemy.transform.position = new Vector2(Border.Instance.GetRandomX(),
                    _currentHeight + Random.Range(-_enemyCreationYPosRange, _enemyCreationYPosRange));
            }

            if (Random.Range(0, 100) < _coinCreationProbability && _coinPrefab != null)
            {
                GameObject coin = Instantiate(_coinPrefab);
                coin.transform.position = temp.transform.position + Vector3.up;
                coin.transform.parent = temp.transform;
            }
        }
    }

#if UNITY_EDITOR

    void OnValidate()
    {
        if (_minYGenerationRange > _maxYGenerationRange)
            _minYGenerationRange = _maxYGenerationRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        float X = Border.Instance?.RightBorderX ?? 10;
        Gizmos.DrawLine(new Vector3(-X, _currentHeight +_spawnDistance),
            new Vector3(X, _currentHeight +_spawnDistance));
    }

#endif
}
