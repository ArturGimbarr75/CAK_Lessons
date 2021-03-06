using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventHealth : UnityEvent<HealthEventArgs> { }

public class HealthEventArgs : EventArgs
{
    public float CurrentHealth;
    public float MaxHealth;
}