using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MedkitUI : MonoBehaviour
{
    [SerializeField] private TriggerMedkitForPlayer _medkit;
    [SerializeField] private TMP_Text _text;

    void Start()
    {
        _medkit.OnMedkitUsed.AddListener(UpdateUI);
        UpdateUI(new MedkitEventArgs() { LeftHealth = _medkit.LeftHealth });
    }

    void UpdateUI(MedkitEventArgs args)
    {
        _text.text = $"{(int)args.LeftHealth}";
    }

    void OnDisable()
    {
        _medkit.OnMedkitUsed.RemoveListener(UpdateUI);
    }
}
