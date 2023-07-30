using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [Header ("Enemy Spawns")]
    //[SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float enemyRespawnTimerMin = 1f;
    [SerializeField] private float enemyRespawnTimerMax = 5f;
    [SerializeField] private List<GameObject> enemyPrefabs;
    private GameObject _randomEnemy;

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
            _randomEnemy = RandomEnemy();
            GameObject newEnemy = Instantiate(_randomEnemy, enemySpawnPosition, Quaternion.identity);
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

    GameObject RandomEnemy()
    {
        float randomValue = Random.value;
        if (0 <= randomValue && randomValue < 0.8) // 80% small ones
        {
            _randomEnemy = enemyPrefabs[0];
        }
        else if (0.8 <= randomValue && randomValue <= 1)
        {
            _randomEnemy = enemyPrefabs[1];
        }
        return _randomEnemy;
    }

    public void OnPlayerDeath()
    {
        isSpawning = false;
    }
}
