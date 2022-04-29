using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider hpSlider;

    public void SetMaxHealth(int health)
    {
        hpSlider.maxValue = health;
        hpSlider.value = health;
    }

    public void SetHealth(int health)
    {
        hpSlider.value = health;
    }
}
