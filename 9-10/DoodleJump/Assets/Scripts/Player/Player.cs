using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Transform Instance { get; private set; }

    void Awake() => Instance = transform;
}
