using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance => s_instance;

    private static Player s_instance;

    void Awake()
    {
        s_instance = this;
    }
}
