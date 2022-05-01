using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
