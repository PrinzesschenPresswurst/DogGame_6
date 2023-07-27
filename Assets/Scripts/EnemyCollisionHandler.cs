using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyCollisionHandler : MonoBehaviour
{
    private ScoreKeeper _scoreKeeper;
    private PlayerLife _playerLife;
    

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playerLife = other.GetComponent<PlayerLife>();
        switch (other.tag)
        {
            case "Player": 
                _playerLife.Damage();
                Destroy(this.gameObject);
                break;
            
            case "Player_Shield": 
                _scoreKeeper.UpdateScore(); 
                Destroy(this.gameObject);
                break;
            
            case "Laser": 
                _scoreKeeper.UpdateScore(); 
                Destroy(other.gameObject); 
                Destroy(this.gameObject);
                break;
        }
    }
}
