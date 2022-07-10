using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnStartClick() => SceneManager.LoadScene(1);

    public void OnBackClick() => SceneManager.LoadScene(0);

    public void OnQuitClick() => Application.Quit();
}
