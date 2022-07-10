using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    [SerializeField, Min(0)] private float _fallDistance; 
    [SerializeField] private GameObject _endGamePanel;

    private float _currentHeight;

    void Start()
    {
        _currentHeight = -_fallDistance;
    }

    void Update()
    {
        if (Player.Instance.position.y - _fallDistance > _currentHeight)
            _currentHeight = Player.Instance.position.y - _fallDistance;

        if (Player.Instance.position.y < _currentHeight)
        {
            _endGamePanel?.SetActive(true);
         
            GetComponent<Score>().UpdatePanelInfo();

            Destroy(GetComponent<HorizontalDrag>());
            Destroy(GetComponent<PlayerHorizontalMovement>());
            Destroy(GetComponent<PlayerJump>());
            Destroy(GetComponent<Rigidbody2D>());
            Destroy(this);
        }
    }

#if UNITY_EDITOR

    void OnValidate() => _currentHeight = -_fallDistance;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float X = Border.Instance?.RightBorderX ?? 10;
        Gizmos.DrawLine(new Vector3(-X, _currentHeight),
            new Vector3(X, _currentHeight));
    }

#endif
}
