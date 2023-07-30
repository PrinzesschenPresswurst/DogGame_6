using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI endScreenScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int _score;
    
    void Start()
    {
        scoreText.text = "Score: 000";
    }

    public void UpdateScore()
    {
        _score = _score +100;
        scoreText.text = "Score:" +_score;
    }

    public void OnScorePowerUpCollect()
    {
        _score = _score + 500;
        scoreText.text = "Score:" +_score;
    }

    public void UpdateEndScore()
    {
        endScreenScoreText.text = "Your score was: " + _score;
        int highScore = PlayerPrefs.GetInt("Highscore");

        if (highScore < _score)
        {
            highScoreText.text = "WOW NEW HIGHSCORE! You broke the previous highscore of " + highScore;
            highScoreText.color = Color.green;
            PlayerPrefs.SetInt("Highscore", _score);
            PlayerPrefs.Save();
        }
        
        else if (highScore >= _score)
        {
            highScoreText.text = "No new Highscore. Current best is still: " + highScore;
            highScoreText.color = Color.gray;
        }
        
    }
}
