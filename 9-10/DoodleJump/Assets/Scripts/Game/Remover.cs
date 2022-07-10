using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField, Min(0)] private float _removeDistance;

    void Update()
    {
        if (Player.Instance.position.y - _removeDistance > transform.position.y)
            Destroy(gameObject);
    }
}
