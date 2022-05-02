using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject audioSource;
    public Animator MusicIconAnimator;

    public bool musicOff;

    void Start()
    {
        musicOff = false;
    }

    public void MusicOff()
    {
        if (musicOff == false)
        {
            MusicIconAnimator.SetBool("MusicOff", true);
            audioSource.SetActive(false);
            musicOff = true;
        }
        else
        {
            MusicIconAnimator.SetBool("MusicOff", false);
            audioSource.SetActive(true);
            musicOff = false;
        }
    }
}
