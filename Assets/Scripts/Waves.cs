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

    public float timeBetweenWaves = 10f;
    public float startCountdown = 30f;
    public float waveCounter = 1f;

    private float randomSpawnPos;

    public static bool gameIsWon;
    public bool GameStop = false;
    public bool isPaused;

    private int waveIndex = 0;

    void Start()
    {
        isPaused = false;
        GameStop = false;
        waveCounter = 1f;
        gameIsWon = false;
    }

    void Update()
    {
        if (startCountdown <= 0)
        {
            StartCoroutine(SpawnWave());
            startCountdown = timeBetweenWaves;
        }

        startCountdown -= Time.deltaTime;

        startCountdown = Mathf.Clamp(startCountdown, 0f, Mathf.Infinity);

        waveInfoText.text = " wave " + waveCounter + ": " + string.Format("{0:00}", startCountdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(2.0f);
        }

        waveCounter++;
    }

    void SpawnEnemy()
    {

        if (waveCounter < 5 && GameStop == false)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        }
        else
        {
            GameStop = true;
            GameOver();
        }
    }
    void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;

        PauseMenu pauseMenu = GetComponent<PauseMenu>();
        pauseMenu.GameLost = true;
        gameIsWon = true;
        gameWonUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
}