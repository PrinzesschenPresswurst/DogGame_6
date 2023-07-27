using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [Header ("Enemy Spawns")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float enemyRespawnTimerMin = 1f;
    [SerializeField] private float enemyRespawnTimerMax = 5f;
    
    [Header ("PowerUp Spawns")]
    [SerializeField] private float powerUpRespawnTimerMin = 5f;
    [SerializeField] private float powerUpRespawnTimerMax = 10f;
    [SerializeField] private List<GameObject> powerUpPrefabs;

    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnEnemy()
    {
        while (isSpawning)
        {
            Vector3 enemySpawnPosition = new Vector3(Random.Range(-6f, 6f), 7f, 0f);
            GameObject newEnemy = Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);
            newEnemy.transform.SetParent(enemyContainer.transform);
            yield return new WaitForSeconds(Random.Range(enemyRespawnTimerMin,enemyRespawnTimerMax));
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(Random.Range(powerUpRespawnTimerMin,powerUpRespawnTimerMax));
            Vector3 powerUpSpawnPosition = new Vector3(Random.Range(-6f, 6f), Random.Range(-2f, 4f), 0f);
            GameObject powerUp = powerUpPrefabs[Random.Range(0,powerUpPrefabs.Count)];
            Instantiate(powerUp, powerUpSpawnPosition, Quaternion.identity);
        }
    }

    
    public void OnPlayerDeath()
    {
        isSpawning = false;
    }
}
