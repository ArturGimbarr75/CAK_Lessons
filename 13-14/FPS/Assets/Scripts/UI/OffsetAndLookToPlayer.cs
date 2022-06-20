using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OffsetAndLookToPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;

    void Update()
    {
        transform.position = _offset + transform.parent.position;
        transform.LookAt(Player.Instance.transform.position);
    }

#if UNITY_EDITOR

    private void OnValidate()
    {
        if (transform.parent != null)
        transform.position = transform.parent.position + _offset;
    }

#endif
}
