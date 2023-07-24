using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject laserProjectile;
    [SerializeField] private GameObject tripleShot;
    [SerializeField] private Vector3 spawnOffset = new Vector3(0,0.8f,0);
    [SerializeField] private float spawnLaserCooldown = 0.3f;
    private float _nextLaserAvailable = 0f;
    private bool _tripleShotActive = false;
    [SerializeField] private float _tripleShotDuration = 5f;

    private void Update()
    {
        if (!_tripleShotActive)
        {
            SpawnLaser();
        }
        else if (_tripleShotActive)
        {
            SpawnTripleShot();
        }
    }

    private void SpawnLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextLaserAvailable)
        {
            _nextLaserAvailable = Time.time + spawnLaserCooldown;
            Instantiate(laserProjectile, transform.position + spawnOffset ,Quaternion.identity);
        } 
    }

    private void SpawnTripleShot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextLaserAvailable)
        {
            _nextLaserAvailable = Time.time + spawnLaserCooldown;
            Instantiate(tripleShot, transform.position ,Quaternion.identity);
        } 
    }

    public void OnTripleShotCollect()
    {
        _tripleShotActive = true;
        Invoke("ResetTripleShot",_tripleShotDuration);
    }

    private void ResetTripleShot()
    {
        _tripleShotActive = false;
    }
}
