using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("UI objects")]
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject outOfTimeText;
    [SerializeField] private GameObject impostorText;
    [SerializeField] private TMPro.TextMeshProUGUI timeText;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    // Hardcoded variables you may want to tune.
    private float startingTime = 160f;

    // Global variables
    private float timeRemaining;
    private int score;
    private bool playing = false;

    // This is public so the play button can see it.
    public void StartGame()
    {
        // Hide/show the UI elements we don't/do want to see.
        playButton.SetActive(false);
        outOfTimeText.SetActive(false);
        impostorText.SetActive(false);
        gameUI.SetActive(true);

        // Start with 30 seconds.
        timeRemaining = startingTime;
        score = 0;
        scoreText.text = "0";
        playing = true;
    }

    public void GameOver(int type)
    {
        // Show the message.
        if (type == 0)
        {
            outOfTimeText.SetActive(true);
        }
        else
        {
            impostorText.SetActive(true);
        }
        // Hide all moles.
        // Stop the game and show the start UI.
        playing = false;
        playButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            // Update time.
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver(0);
            }
            timeText.text = $"{(int)timeRemaining / 60}:{(int)timeRemaining % 60:D2}";
            // Check if we need to start any more moles.
        }
    }

    public void AddScore()
    {
        // Add and update score.
        score += 1;
        scoreText.text = $"{score}";
        // Increase time by a little bit.
        timeRemaining += 1;
    }
}