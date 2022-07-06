using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerEndHealth : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private GameObject _pausePanel;

    private Health _health;

    void OnEnable()
    {
        _health ??= GetComponent<Health>();
        _health.OnHealthEnd.AddListener(OnEndHealth);
    }

    void OnEndHealth()
    {
        _pause.enabled = false;
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void OnDisable()
    {
        _health.OnHealthEnd.RemoveListener(OnEndHealth);
    }
}
