using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthBar;
    public GameObject gameLostUI;

    public int startingHealth = 100;
    public int currentHealth;

    void Start()
    {
        SetMaxHealth(startingHealth);
        SetHealth(currentHealth);
    }

    public void SetMaxHealth(int health)
    {
        playerHealthBar.maxValue = health;
        playerHealthBar.value = health;
    }

    public void SetHealth(int health)
    {
        playerHealthBar.value = health;
    }

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;

        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            gameLostUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
    }
}
