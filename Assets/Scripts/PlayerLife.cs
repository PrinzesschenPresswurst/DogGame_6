using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private Material crashMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Image life1Image;
    [SerializeField] private Image life2Image;
    [SerializeField] private Image life3Image;
    private SpawnManager _spawnManager;
    private MeshRenderer _renderer;

    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _renderer = GetComponent<MeshRenderer>();
    }

    public void Damage()
    {
        playerLives--;
        StartCoroutine(CrashFeedback());
        UpdateLifeUI();
        
        if (playerLives <= 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    private void UpdateLifeUI()
    {
        if (playerLives == 2)
        {
            life3Image.enabled = false;
        }

        if (playerLives == 1)
        {
            life2Image.enabled = false;
        }
        
        if (playerLives <= 0)
        {
            life1Image.enabled = false;
        }
    }

    private IEnumerator CrashFeedback()
    {
        for (int i = 0; i < 1; i++)
        {
            _renderer.material = crashMaterial;
            yield return new WaitForSeconds(0.1f);
            _renderer.material = defaultMaterial;
        }
    }
}