using UnityEngine.SceneManagement;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public static bool isPaused = false;
    public bool GameWon = false;
    public bool GameLost = false;

    public GameObject mainUI;
    public GameObject GameLostUI;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown("escape") || GameWon || GameLost)
        {
            Cursor.lockState = CursorLockMode.None;

            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        else
        {
            return;
        }
    }

    void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Cursor.lockState = CursorLockMode.None;
        GameLostUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}