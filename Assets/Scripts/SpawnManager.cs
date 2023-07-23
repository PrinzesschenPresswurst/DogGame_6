using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject enemyContainer;
    [SerializeField] private float respawnTimerMin = 1f;
    [SerializeField] private float respawnTimerMax = 5f;

    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (isSpawning)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 8f, 0f);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.transform.SetParent(enemyContainer.transform);
            yield return new WaitForSeconds(Random.Range(respawnTimerMin,respawnTimerMax));
        }
    }

    public void OnPlayerDeath()
    {
        isSpawning = false;
    }
}
