using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    public GameObject menuUI;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
