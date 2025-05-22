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

    private float currentTime;
    private bool timerRunning = true;
    private int score;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Scorre : " + score;
        currentTime = countdownTime;
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = 0;
                timerRunning = false;

                // Optional: Trigger game over
                Debug.Log("Time's up!");
            }

            int minutes = Mathf.FloorToInt(currentTime / 60f);
            int seconds = Mathf.FloorToInt(currentTime % 60f);

            timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score : " + score;
    }
}
