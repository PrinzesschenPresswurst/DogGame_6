using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 3f;
    [SerializeField] private float enemyDestroyDistance = -4f;
    [SerializeField] private float respawnPositionY = 7f;
 
    private void Update()
    {
       MoveEnemy();
       RespawnEnemyAfterLeavingScreen();
    }

    private void MoveEnemy()
    {
        float enemyMoveSpeedFactor = enemyMoveSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * enemyMoveSpeedFactor);
    }

    private void RespawnEnemyAfterLeavingScreen()
    {
        if (transform.position.y < enemyDestroyDistance)
        {
            float respawnPositionX = Random.Range(-6f, 6f);
            transform.position = new Vector3(respawnPositionX, respawnPositionY, 0);
        }
    }
}
