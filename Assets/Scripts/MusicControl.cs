using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public GameObject audioSource;
    public Animator MusicIconAnimator;

    public bool musicOff;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>().gameObject;
        MusicIconAnimator.SetBool("MusicOff", false);
        musicOff = false;
    }

    void MusicOff()
    {
        MusicIconAnimator.SetBool("MusicOff", true);
        audioSource.SetActive(false);
        musicOff = true;
    }
    void MusicOn()
    {
        MusicIconAnimator.SetBool("MusicOff", false);
        audioSource.SetActive(true);
        musicOff = false;
    }

    public void MusicChange()
    {
        if (musicOff == false)
        {
            MusicOff();
        }
        else
        {
            MusicOn();
        }
    }
}
