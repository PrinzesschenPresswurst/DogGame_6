using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
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
}
