using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraState : MonoBehaviour
{
    private Scanner _scanner;
    private bool _isOn = true;

    void Start()
    {
        _scanner = GetComponent<Scanner>();
    }

    public void ChangeState()
    {
        _isOn = !_isOn;
        _scanner.enabled = _isOn;
    }
}
