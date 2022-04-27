using UnityEngine;


public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    public GameObject gameLostUI;

    public PlayerHealthBar playerHealthBar;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            PlayerTakeDamage(20);

            return;
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        currentHealth -= damage;

        playerHealthBar.SetHealth(currentHealth);

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
