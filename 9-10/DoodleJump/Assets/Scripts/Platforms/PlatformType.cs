using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformType : MonoBehaviour
{
    public TypeOfPlatform Type => _type;

    [SerializeField] private TypeOfPlatform _type;

    public enum TypeOfPlatform
    {
        None,
        Simple,
        Boost,
        Fake,
        Single
    }
}
