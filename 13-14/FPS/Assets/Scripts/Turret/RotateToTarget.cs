using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    public Transform Target { get => _target; set => _target = value; }
    public float VerticalOffset { get => _verticalOffset; set => _verticalOffset = value; }

    [SerializeField] private Transform _target;
    [SerializeField] private float _verticalOffset;
    [SerializeField, Range(-180, 0)] private float _minVerticalAngle;
    [SerializeField, Range(0, 180)] private float _maxVerticalAngle;
    /*[SerializeField] private bool _useHorizontalRange;
    [SerializeField, Range(0, 360)] private float _maxHorizontalAngle;*/
    [SerializeField, Range(0.1f, 50f)] private float _speed;

    /*void Update()
    {
        if (_target == null)
            return;

        Vector3 targetDir = transform.InverseTransformPoint(_target.position) + Vector3.up * _verticalOffset;

        Vector3 euler = Quaternion.RotateTowards(transform.localRotation,
            Quaternion.LookRotation(targetDir),
            Time.deltaTime * _speed).eulerAngles;
        if (euler.x > 180)
            euler.x -= 360;
        euler.x = Mathf.Clamp(euler.x, _minVerticalAngle, _maxVerticalAngle);
        if (_useHorizontalRange)
        {
            if (euler.y > 180)
                euler.y -= 180;
            euler.y = Mathf.Clamp(euler.y, -_maxHorizontalAngle / 2, _maxHorizontalAngle / 2);
        }

        euler.z = transform.rotation.z;

        transform.localRotation = Quaternion.Euler(euler);
    }*/

    void Update()
    {
        if (_target == null)
            return;

        Vector3 targetDir = _target.position - transform.position + Vector3.up * _verticalOffset;

        Vector3 euler = Quaternion.RotateTowards(transform.rotation,
            Quaternion.LookRotation(targetDir),
            Time.deltaTime * _speed).eulerAngles;
        if (euler.x > 180)
            euler.x -= 360;
        euler.x = Mathf.Clamp(euler.x, _minVerticalAngle, _maxVerticalAngle);
        euler.z = transform.rotation.z;

        transform.rotation = Quaternion.Euler(euler);
    }
/*
#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        if (!_useHorizontalRange)
            return;

        Gizmos.color = Color.blue;
        float yRotation = Mathf.Deg2Rad * transform.rotation.eulerAngles.y;
        float leftRad = Mathf.Deg2Rad * _maxHorizontalAngle / 2 + yRotation;
        float rightRad = -Mathf.Deg2Rad * _maxHorizontalAngle / 2 + yRotation;
        Vector3 leftAngle = new Vector3(Mathf.Sin(leftRad), 0, Mathf.Cos(leftRad)).normalized;
        Vector3 rightAngle = new Vector3(Mathf.Sin(rightRad), 0, Mathf.Cos(rightRad)).normalized;
        //leftAngle *= _viewDistance;
        //rightAngle *= _viewDistance;
        Gizmos.DrawLine(transform.position, transform.position + leftAngle);
        Gizmos.DrawLine(transform.position, transform.position + rightAngle);
    }

#endif*/
}
