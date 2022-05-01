using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditsUI : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
