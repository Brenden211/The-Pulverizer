using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startHealth = 100f;
    public float damage = 20f;
    public Slider slider;

    private float health;

    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void TakeDamage(float amount)
    {
        startHealth -= damage;

        if (slider.value <= 0)
        {
            EnemyMovement enemyMovement = GetComponent<EnemyMovement>();

            enemyMovement.Die();
        }
    }
}