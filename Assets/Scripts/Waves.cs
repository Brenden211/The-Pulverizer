using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;


public class Waves : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public GameObject gameWonUI;
    public Text waveInfoText;
    public Text enemiesAliveText;

    public float timeBetweenWaves;
    public float startCountdown;
    public float waveCounter;
    public int waveIndex = 0;
    public int enemiesAlive;

    public bool gameIsWon;
    public bool endWaves;

    GameUI gameUI;

    void Start()
    {
        waveCounter = 1f;
        gameIsWon = false;
        endWaves = false;
    }

    void Update()
    {

        if (startCountdown <= 0)
        {
            StartCoroutine(SpawnWave());
            startCountdown = timeBetweenWaves;
        }

        if (endWaves == false)
        {
            startCountdown -= Time.deltaTime;
            startCountdown = Mathf.Clamp(startCountdown, 0f, Mathf.Infinity);
            waveInfoText.text = " wave " + waveCounter + ": " + string.Format("{0:00}", startCountdown);
            enemiesAliveText.text = " enemies Alive: " + enemiesAlive;
        }
        if (enemiesAlive == 0 && waveCounter == 6 || Input.GetButtonDown("GameWon"))
        {
            gameUI = GameObject.FindGameObjectWithTag("GameUI").GetComponent<GameUI>();

            gameUI.GameWon();
        }
        else
        {
            return;
        }
    }

    IEnumerator SpawnWave()
    {

        if (endWaves == false)
        {
            waveIndex++;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(2.0f);
            }

            waveCounter++;
        }
    }

    void SpawnEnemy()
    {

        if (waveCounter < 5)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemiesAlive = enemiesAlive + 3;

        }
        else
        {
            endWaves = true;
            waveInfoText.text = " waves finished ";
        }
    }

    public void KillEnemy()
    {
        enemiesAlive = enemiesAlive - 1;
        enemiesAliveText.text = " enemies Alive: " + enemiesAlive;
    }
}