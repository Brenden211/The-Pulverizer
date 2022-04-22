using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Points;
    public static int Rounds;
    public static int damageTake = 2;
    public int startingPoints = 300;

    public static float playerHP;
    public float playerStartingHP = 10f;

    void Start()
    {
        Points = startingPoints;
        Rounds = 0;
        playerHP = playerStartingHP;
    }

    public void PlayerTakeDamage(float amount)
    {
        if (playerHP == 0)
        {
            Debug.Log("Player Has Lost!");
        }
        else
        {
            return;
        }
    }
}
