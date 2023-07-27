using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private Canvas endScreenCanvas;
    private ScoreKeeper _scoreKeeper;
    void Start()
    {
        gameCanvas.enabled = true;
        endScreenCanvas.enabled = false;
        _scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void OnPlayerDeath()
    {
        gameCanvas.enabled = false;
        endScreenCanvas.enabled = true;
        _scoreKeeper.UpdateEndScore();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
        
}
