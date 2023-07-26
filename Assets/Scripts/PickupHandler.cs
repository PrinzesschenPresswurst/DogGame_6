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

    private void Start()
    {
        _playerFire = GetComponent<PlayerFire>();
        _playerController = GetComponent<PlayerController>();
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
        _audioSource = GetComponent<AudioSource>();
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
                //TODO add health powerup
            }
            _audioSource.PlayOneShot(powerUpCollect);
            Destroy(other.gameObject);
        }
    }
}
