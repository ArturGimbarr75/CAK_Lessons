using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public static Border Instance { get; private set; }
    public float Width => _width;
    public float LeftBorderX => -_width / 2;
    public float RightBorderX => _width / 2;

    [SerializeField, Min(0)] private float _width;

    void Awake() => Instance = this;

    public float GetRandomX() => Random.Range(LeftBorderX, RightBorderX);

#if UNITY_EDITOR

    void OnDrawGizmos()
    {
        const float Y_POS = 10000;
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(LeftBorderX, Y_POS), new Vector3(LeftBorderX, -Y_POS));
        Gizmos.DrawLine(new Vector3(RightBorderX, Y_POS), new Vector3(RightBorderX, -Y_POS));
    }

    void OnValidate() => Instance = this;

#endif
}
