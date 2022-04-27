using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealth;

    public EnemyHealthBar enemyHealthBar;

    private float health;

    void Start()
    {
        currentHealth = startHealth;
        enemyHealthBar.SetMaxHealth(startHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        enemyHealthBar.SetHealth(currentHealth);

        if (health <= 0)
        {
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

            enemyMovement.Die();
        }
    }
}