using UnityEngine.UI;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemyHealthBar;

    public int enemyStartingHealth = 100;
    public int enemyCurrentHealth;

    void Start()
    {
        EnemySetMaxHealth(enemyStartingHealth);
        EnemySetHealth(enemyCurrentHealth);
    }
    public void EnemySetMaxHealth(int health)
    {
        enemyHealthBar.maxValue = health;
        enemyHealthBar.value = health;
    }

    public void EnemySetHealth(int health)
    {
        enemyHealthBar.value = health;
    }

    public void EnemyTakeDamage(int damage)
    {
        Debug.Log("Working!");

        enemyCurrentHealth -= damage;

        EnemySetHealth(enemyCurrentHealth);

        if (enemyCurrentHealth <= 0)
        {
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

            enemyMovement.Die();
        }
    }
}