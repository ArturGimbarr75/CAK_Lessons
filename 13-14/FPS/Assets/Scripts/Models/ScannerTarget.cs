using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerTarget : IEquatable<ScannerTarget>
{
    public Transform Target { get; set; }
    public bool IsVisible { get; set; }
    public CharacterType.Type Type { get; set; }

    public override bool Equals(object obj) => Equals(obj as ScannerTarget);
    public bool Equals(ScannerTarget other) => Target.Equals(other.Target);
    public override int GetHashCode() => Target.GetHashCode();
}
