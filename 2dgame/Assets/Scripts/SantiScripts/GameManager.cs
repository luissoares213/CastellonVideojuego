using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<TopoArbol1> niños;

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
    public bool isAWin;
    private HashSet<TopoArbol1> currentNiños = new HashSet<TopoArbol1>();

    // This is public so the play button can see it.
    public void StartGame()
    {
        // Hide/show the UI elements we don't/do want to see.
        playButton.SetActive(false);
        outOfTimeText.SetActive(false);
        impostorText.SetActive(false);
        gameUI.SetActive(true);

        for (int i = 0; i < niños.Count; i++)
        {
            niños[i].Hide();
            niños[i].SetIndex(i);
        }

        // Remove any old game state.
        currentNiños.Clear();

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
        foreach (TopoArbol1 niño in niños)
        {
            niño.StopGame();
        }
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
            if (currentNiños.Count <= (1))
            {
                // Choose a random mole.
                int index = Random.Range(0, niños.Count);
                // Doesn't matter if it's already doing something, we'll just try again next frame.
                if (!currentNiños.Contains(niños[index]))
                {
                    currentNiños.Add(niños[index]);
                    niños[index].Activate();
                }
            }
        }
    }

    public void AddScore(int niñoIndex)
    {

        // Add and update score.
        score += 1;
        scoreText.text = $"{score}";
        // Increase time by a little bit.

        currentNiños.Remove(niños[niñoIndex]);
    }

    public void RemoveSCORE(int niñoIndex)
    {
        score -= 2;
        scoreText.text = $"{score}";
        // Increase time by a little bit.

        currentNiños.Remove(niños[niñoIndex]);
    }

    public void itsAWin()
    {
        if (score >= 20)
        {
            isAWin = true;
        }
        else
        {
            isAWin = false;
        }
    }

    public void Missed(int moleIndex, bool isMole)
    {
        // Remove from active moles.
        currentNiños.Remove(niños[moleIndex]);
    }
}