using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public float countdownTime = 60f; // e.g., 1 minute
    public GameObject player; // Assign this in the Inspector

    private float currentTime;
    private bool timerRunning = true;
    private int score;

    private int lastScoreThreshold = 0;  // Tracks last 50-point milestone

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentTime = countdownTime;
        scoreText.text = "Score : " + score;
    }

    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerRunning = false;

                // Destroy the player
                if (player != null)
                {
                    Destroy(player);
                    Debug.Log("Time's up! Player destroyed.");
                }
            }

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            timerText.text = string.Format(" {0:00}:{1:00}", minutes, seconds);
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score : " + score;

        // Check if score passed a new 50 point threshold
        int currentThreshold = (score / 50) * 50;
        if (currentThreshold > lastScoreThreshold)
        {
            currentTime += 10f; // Add 10 seconds to timer
            lastScoreThreshold = currentThreshold;
            Debug.Log($"Score reached {currentThreshold}, added 10 seconds to timer.");
        }
    }

    public int GetScore()
    {
        return score;
    }
}
