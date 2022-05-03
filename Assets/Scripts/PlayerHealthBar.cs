using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthBar;
    public GameObject gameLostUI;

    public int startingHealth = 100;
    public int currentHealth;

    GameUI gameUI;

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
        FindObjectOfType<AudioManager>().Play("Hurt Sound");
        currentHealth -= damage;

        SetHealth(currentHealth);

        if (currentHealth <= 0)
        {

            gameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameUI>();

            gameUI.GameLost();
        }
        else
        {
            return;
        }
    }
}
