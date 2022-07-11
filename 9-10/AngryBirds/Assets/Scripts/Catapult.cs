using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    [Header("Birds"), Space(5)]
    [SerializeField] private List<GameObject> _birdPrefabsPool;

    [Header("Params")]
    [SerializeField, Range(0.5f, 3)] private float _maxDistanceFromCatapult;
    [SerializeField, Range(0, 50)] private float _impulse;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _distanceInQueue;

    private GameObject _currentBird;
    private List<GameObject> _pool;

    void Start()
    {
        _pool = new List<GameObject>();
        Vector3 pos = transform.position + _offset;
        foreach (GameObject bird in _birdPrefabsPool)
        {
            _pool.Add(Instantiate(bird, pos, Quaternion.identity));
            pos += Vector3.left * _distanceInQueue;
        }
    }

    private void OnMouseDown()
    {
        if (_pool.Count <= 0)
            return;

        for (int i = _pool.Count - 1; i > 0; i--)
            _pool[i].transform.position = _pool[i - 1].transform.position;

        _currentBird = _pool[0];
        _pool.RemoveAt(0);
    }

    private void OnMouseDrag()
    {
        if (_currentBird == null)
            return;

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _currentBird.transform.position = Vector2.MoveTowards(transform.position, mouse,
            Mathf.Min(Vector2.Distance(transform.position, mouse), _maxDistanceFromCatapult));
    }

    private void OnMouseUp()
    {
        if (_currentBird == null)
            return;

        _currentBird.GetComponent<Collider2D>().enabled = true;
        Vector2 direction = (transform.position - _currentBird.transform.position);
        float force = direction.magnitude / _maxDistanceFromCatapult;
        _currentBird.AddComponent<Rigidbody2D>()
            .AddForce(direction.normalized * _impulse * force, ForceMode2D.Impulse);
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        const float SPHERE_SIZE = 0.1f;
        Gizmos.color = Color.yellow;
        Vector3 pos = transform.position + _offset;
        for (int i = 0; i < _birdPrefabsPool.Count; i++)
        {
            Gizmos.DrawSphere(pos, SPHERE_SIZE);
            pos += Vector3.left * _distanceInQueue;
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _maxDistanceFromCatapult);
    }

#endif
}
