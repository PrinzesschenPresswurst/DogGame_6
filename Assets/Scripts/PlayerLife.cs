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
    [SerializeField] private TextMeshProUGUI maxFeedbackText;
    private SpawnManager _spawnManager;
    private GameManager _gameManager;
    private MeshRenderer _renderer;

    private void Start()
    {
        _spawnManager = FindObjectOfType<SpawnManager>();
        _gameManager = FindObjectOfType<GameManager>();
        _renderer = GetComponent<MeshRenderer>();
        maxFeedbackText.enabled = false;
    }

    public void Damage()
    {
        playerLives--;
        StartCoroutine(CrashFeedback());
        UpdateLifeUI();
        
        if (playerLives <= 0)
        {
            _spawnManager.OnPlayerDeath();
            _gameManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    private void UpdateLifeUI()
    {
        switch (playerLives)
        {
            case 3:
                life1Image.enabled = true;
                life2Image.enabled = true;
                life3Image.enabled = true;
                break;
            case 2:
                life1Image.enabled = true;
                life2Image.enabled = true;
                life3Image.enabled = false;
                break;
            case 1:
                life1Image.enabled = true;
                life2Image.enabled = false;
                break;
            case 0:
                life1Image.enabled = false;
                break;
        }
    }

    private IEnumerator CrashFeedback()
    {
        _renderer.material = crashMaterial;
        yield return new WaitForSeconds(0.1f);
        _renderer.material = defaultMaterial;
    }

    public void OnHealthCollected()
    {
        if (playerLives < 3)
        {
            playerLives++;
            UpdateLifeUI();
        }
        else if (playerLives == 3)
        {
            StartCoroutine(MaxLifeFeedback());
        }
    }
    
    IEnumerator MaxLifeFeedback()
    {
        maxFeedbackText.enabled = true;
        yield return new WaitForSeconds(0.2f);
        maxFeedbackText.enabled = false;
        yield return new WaitForSeconds(0.2f);
        maxFeedbackText.enabled = true;
        yield return new WaitForSeconds(0.2f);
        maxFeedbackText.enabled = false;
        
    }
}