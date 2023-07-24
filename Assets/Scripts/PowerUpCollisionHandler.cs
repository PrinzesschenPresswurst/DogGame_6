using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollisionHandler : MonoBehaviour
{
    private PlayerFire _playerFire;

    private void Start()
    {
        _playerFire = FindObjectOfType<PlayerFire>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp_TripleShot"))
        {
            Destroy(other.gameObject);
            _playerFire.OnTripleShotCollect();
        }
    }
}
