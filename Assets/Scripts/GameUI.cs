using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool GameWon = false;
    public bool GameLost = false;

    public GameObject GameLostUI;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Pause();
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
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