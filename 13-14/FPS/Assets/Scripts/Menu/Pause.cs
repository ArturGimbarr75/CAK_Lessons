using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    private bool _isPaused = false;

    void Start()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;
            Time.timeScale = _isPaused ? 0f : 1f;
            Cursor.lockState = _isPaused ? CursorLockMode.Confined : CursorLockMode.Locked;
            _pausePanel.SetActive(_isPaused);
        }
    }
}
