using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal interface IInteractable
{
    string Info { get; }

    void DoAction();
}
