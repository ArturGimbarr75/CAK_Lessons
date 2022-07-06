using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;
    }

    public void LoadLevel(int index) => SceneManager.LoadScene(index);

    public void Quit() => Application.Quit();
}
