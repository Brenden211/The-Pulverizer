using UnityEngine.SceneManagement;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public bool gameIsPaused = false;
    public bool gameWon = false;
    public bool gameLost = false;

    public GameObject GameLostUI;
    public GameObject GameWonUI;
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

    public void GameWon()
    {
        gameIsPaused = true;
        GameWonUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void GameLost()
    {
        gameIsPaused = true;
        GameLostUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}