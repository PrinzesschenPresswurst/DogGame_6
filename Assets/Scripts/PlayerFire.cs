using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject laserProjectile;
    [SerializeField] private Vector3 spawnOffset = new Vector3(0,0.8f,0);
    [SerializeField] private float spawnLaserCooldown = 0.3f;
    private float _nextLaserAvailable = 0f;

    private void Update()
    {
        SpawnLaser();
    }

    private void SpawnLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextLaserAvailable)
        {
            _nextLaserAvailable = Time.time + spawnLaserCooldown;
            Instantiate(laserProjectile, transform.position + spawnOffset ,Quaternion.identity);
        } 
    }
}
