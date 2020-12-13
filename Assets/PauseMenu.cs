using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public bool isInOption= false;
    public GameObject pauseMenuUI;
    public GameObject optionMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInOption)
            {
                isInOption = false;
                optionMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
            else if (isPaused)
            {
                Resume();
            }
            else if(!isPaused)
            {
                Pause();
            }
        }
    }

    public void setIsInOption(bool isInOption)
    {
        this.isInOption = isInOption;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
