using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventStealth : UnityEvent<StealthEventArgs> { }

public class StealthEventArgs : EventArgs
{
    public Transform Sender;
    public Transform Target;
    public CharacterType.Type TargetTypes;
    public float ReactionTime;
    public float ForgetTargetTime;
    public float ElapsedReactionTime;
}
