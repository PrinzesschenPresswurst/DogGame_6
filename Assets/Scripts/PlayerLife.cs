using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int playerLives = 3;
    [SerializeField] private Material crashMaterial;
    [SerializeField] private Material defaultMaterial;
    private SpawnManager _spawnManager;
    private Renderer _renderer;

    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        if (_spawnManager != null)
        {
            Debug.Log("SpawnManager is null");
        }
        _renderer = GetComponent<Renderer>();
    }

    public void Damage()
    {
        playerLives--;
        
        StartCoroutine(CrashFeedback());
        
        if (playerLives <= 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    IEnumerator CrashFeedback()
    {
        for (int i = 0; i < 1; i++)
        {
            _renderer.material = crashMaterial;
            yield return new WaitForSeconds(0.2f);
            _renderer.material = defaultMaterial;
        }
    }
}
