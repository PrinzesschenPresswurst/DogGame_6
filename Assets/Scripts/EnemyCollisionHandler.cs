using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyCollisionHandler : MonoBehaviour
{
    private ScoreKeeper _scoreKeeper;

    private void Start()
    {
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerLife playerLife = other.GetComponent<PlayerLife>();
            if (playerLife != null)
            {
                playerLife.Damage();
            }
            
            Destroy(this.gameObject);
        }
        
        else if (other.CompareTag("Laser"))
        {
            _scoreKeeper.UpdateScore();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
