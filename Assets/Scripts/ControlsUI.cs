using UnityEngine.SceneManagement;
using UnityEngine;

public class ControlsUI : MonoBehaviour
{


    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
