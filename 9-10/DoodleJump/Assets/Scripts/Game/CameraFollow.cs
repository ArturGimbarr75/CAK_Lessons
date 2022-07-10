using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField, Min(0)] private float _maxDistance;
    [SerializeField] private float _offsetFromDownCameraPart;

    void LateUpdate()
    {
        float offset = _offsetFromDownCameraPart - Camera.main.orthographicSize;
        Vector3 pos;
        Vector3 playerPos = Player.Instance.position;
        playerPos.x = 0;
        float distance = Mathf.Abs(transform.position.y + offset - Player.Instance.position.y);
        float deltaDistance = distance > _maxDistance ?
            distance - _maxDistance : _speed * Time.deltaTime;
        pos = Vector2.MoveTowards(transform.position,
            playerPos - Vector3.up * offset, deltaDistance);
        pos.z = transform.position.z;
        transform.position = pos;
    }

#if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        float offset = _offsetFromDownCameraPart - Camera.main.orthographicSize;
        Gizmos.DrawWireCube(transform.position + Vector3.up * offset,
            new Vector3(Border.Instance?.Width ?? 100, offset));
    }

    private void OnValidate()
    {
        if (_maxDistance > _offsetFromDownCameraPart)
            _maxDistance = _offsetFromDownCameraPart;
    }

#endif
}
