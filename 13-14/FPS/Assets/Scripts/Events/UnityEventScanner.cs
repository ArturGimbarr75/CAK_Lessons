using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventScanner : UnityEvent<ScannerEventArgs> {}

public class ScannerEventArgs : EventArgs
{
    public Transform Sender;
    public Transform Target;
    public CharacterType.Type TargetType;
}
