using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour, ScoreObserver
{

    private int score;
    public TextMeshProUGUI scoreText;

    public static ScoreManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there's only one instance of ScoreManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional, keep across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
        }
    }
    private void Start()
    {
        UpdateScoreDisplay(); // Initialize score display
    }

    public void OnTargetHit(int points)
    {
        score += points;
        UpdateScoreDisplay(); // Update the display whenever the score changes
    }

    public int GetScore()
    {
        return score;
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the TextMeshProUGUI text
        }
    }
}
