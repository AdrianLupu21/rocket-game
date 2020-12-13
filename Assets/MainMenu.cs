using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0f;
        PauseMenu.isPaused = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("MyScene");
        Time.timeScale = 1f;
        PauseMenu.isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
