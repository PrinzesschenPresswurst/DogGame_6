using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupHandler : MonoBehaviour
{
    [SerializeField] AudioClip powerUpCollect; //TODO
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
        switch (other.tag)
        {
            case "PowerUp_TripleShot":
                _playerFire.OnTripleShotCollect();
                _audioSource.PlayOneShot(powerUpCollect);
                Destroy(other.gameObject);
                break;
            case "PowerUp_Speed": //<<-TODO make this into fire rate cause its lame 
                _playerController.OnSpeedPowerUpCollect();
                _audioSource.PlayOneShot(powerUpCollect);
                Destroy(other.gameObject);
                break;
            case "PowerUp_Score":
                _scoreKeeper.OnScorePowerUpCollect();
                _audioSource.PlayOneShot(powerUpCollect);
                Destroy(other.gameObject);
                break;
            //TODO add health powerup
            default:
                Debug.Log("unhandled coll");
                break;
        }
    }
}
