using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventMedkit : UnityEvent<MedkitEventArgs> { }

public class MedkitEventArgs : EventArgs
{
    public float HealthTaken;
    public float LeftHealth;
}
