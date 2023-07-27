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
        _score++;
        scoreText.text = "Score:" +_score *100;
    }

    public void OnScorePowerUpCollect()
    {
        _score = _score + 5;
        scoreText.text = "Score:" +_score *100;
    }

    public void UpdateEndScore()
    {
        endScreenScoreText.text = "Your score was: " + _score * 100;
        int highScore = PlayerPrefs.GetInt("Highscore");

        if (highScore < _score)
        {
            PlayerPrefs.SetInt("Highscore", _score * 100);
            PlayerPrefs.Save();
            highScoreText.text = "WOW you broke the previous highscore of " + highScore;
            highScoreText.color = Color.green;
        }
        
        else if (highScore >= _score)
        {
            highScoreText.text = "No new Highscore. Current best is still: " + highScore;
            highScoreText.color = Color.gray;
        }
        
    }
}
