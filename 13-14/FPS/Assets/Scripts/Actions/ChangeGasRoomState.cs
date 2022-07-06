using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGasRoomState : MonoBehaviour
{
    [SerializeField] private ParticleSystem _gas; 
    [SerializeField] private TriggerAreaDamager _damager;
    [SerializeField, Min(0)] private float _pauseBeforeTurningOff;

    public void TurnOn()
    {
        _damager.enabled = true;
        _gas.Play();
        CancelInvoke(nameof(TurnOffDamager));
    }

    public void TurnOff()
    {
        _gas.Stop();
        _damager.enabled = false;
        Invoke(nameof(TurnOffDamager), _pauseBeforeTurningOff);
    }

    void TurnOffDamager() => _damager.enabled = false;

}
