using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuPanel : MonoBehaviour
{
    private const int MAIN_MENU_BUILD_INDEX = 0;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        OnChangeScene();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(MAIN_MENU_BUILD_INDEX);
        OnChangeScene();
    }

    private void OnChangeScene()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1.0f;
    }
}
