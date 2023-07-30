using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header ("General")]
    [SerializeField] private float spawnLaserCooldown = 0.3f;
    private float _nextLaserAvailable = 0f;

    [Header ("laserProjectile")]
    [SerializeField] private GameObject laserProjectile;
    
    [Header ("tripleShot PowerUp")]
    [SerializeField] private GameObject tripleShot;
    [SerializeField] private float tripleShotDuration = 5f;
    [SerializeField] private GameObject tripleShotCannons;
    private bool _tripleShotActive = false;
    private float _defaultLaserCooldown;
    
    [Header("laserSpeed PowerUp")]
    [SerializeField] private float laserSpeedPowerUpModifier = 5f;
    [SerializeField] private float laserSpeedPowerUpDuration = 5f;
    private bool _powerUpWasCollected = false;

    private void Start()
    {
        tripleShotCannons.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextLaserAvailable)
        {
            _nextLaserAvailable = Time.time + spawnLaserCooldown;
            DecideProjectile();
        }
    }
    
    private void DecideProjectile()
    {
        if (_tripleShotActive)
        {
            Instantiate(tripleShot, transform.position ,Quaternion.identity);
        }
        else 
        {
            Vector3 spawnOffset = new Vector3(0,0.8f,0);
            Instantiate(laserProjectile, transform.position + spawnOffset ,Quaternion.identity);
        }
    }
    
    public void OnTripleShotCollect()
    {
        _tripleShotActive = true;
        tripleShotCannons.SetActive(true);
        Invoke("ResetTripleShot",tripleShotDuration);
    }

    private void ResetTripleShot()
    {
        _tripleShotActive = false;
        tripleShotCannons.SetActive(false);
    }

    public void OnSpeedPowerUpCollected()
    {
        StartCoroutine(SpeedPowerUp());
    }

    IEnumerator SpeedPowerUp()
    {
        if (!_powerUpWasCollected)
        {
            _powerUpWasCollected = true;
            _defaultLaserCooldown = spawnLaserCooldown;
            spawnLaserCooldown = laserSpeedPowerUpModifier;
            yield return new WaitForSeconds(laserSpeedPowerUpDuration);
            spawnLaserCooldown = _defaultLaserCooldown;
            _powerUpWasCollected = false;
        }
    }
    
}
