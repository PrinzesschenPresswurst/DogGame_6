using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] private AudioClip powerUpCollect; 
    private AudioSource _audioSource;
    private PlayerFire _playerFire;
    private PlayerController _playerController;
    private ScoreKeeper _scoreKeeper;
    private PlayerLife _playerLife;
    private PlayerShieldController _playerShieldController;
    

    private void Start()
    {
        _playerFire = GetComponent<PlayerFire>();
        _playerController = GetComponent<PlayerController>();
        _playerLife = GetComponent<PlayerLife>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioSource = GetComponent<AudioSource>();
        _playerShieldController = GetComponent<PlayerShieldController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")==false)
        {
            switch (other.tag)
            {
                case "PowerUp_TripleShot":
                    _playerFire.OnTripleShotCollect();
                    break;
                case "PowerUp_Speed": //<<-TODO make this into fire rate cause its lame 
                    _playerController.OnSpeedPowerUpCollect();
                    break;
                case "PowerUp_Score":
                    _scoreKeeper.OnScorePowerUpCollect();
                    break;
                case "PowerUp_Life":
                    _playerLife.OnHealthCollected();
                    break;
                case "PowerUp_Shield":
                    _playerShieldController.OnShieldCollected();
                    Debug.Log("collided with shield pickup");
                    break;
            }
            _audioSource.PlayOneShot(powerUpCollect);
            Destroy(other.gameObject);
        }
    }
}
