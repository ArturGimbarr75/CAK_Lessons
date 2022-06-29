using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StealthForPlayer))]
public class TestStealthNotForGame : MonoBehaviour
{
    private StealthForPlayer _stealth;

    void Start()
    {
        _stealth = GetComponent<StealthForPlayer>();
        _stealth.OnCalmDown.AddListener(x => Debug.Log("OnCalmDown"));
        _stealth.OnGetWorried.AddListener(x => Debug.Log("OnGetWorried"));
        _stealth.OnLoseTarget.AddListener(x => Debug.Log("OnLoseTarget"));
        _stealth.OnReact.AddListener(x => Debug.Log("OnReact"));
    }
}
