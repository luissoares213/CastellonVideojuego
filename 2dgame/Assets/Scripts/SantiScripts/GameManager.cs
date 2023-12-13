using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<TopoArbol1> ni�os;

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
    private HashSet<TopoArbol1> currentNi�os = new HashSet<TopoArbol1>();

    // This is public so the play button can see it.
    public void StartGame()
    {
        // Hide/show the UI elements we don't/do want to see.
        playButton.SetActive(false);
        outOfTimeText.SetActive(false);
        impostorText.SetActive(false);
        gameUI.SetActive(true);

        for (int i = 0; i < ni�os.Count; i++)
        {
            ni�os[i].Hide();
            ni�os[i].SetIndex(i);
        }

        // Remove any old game state.
        currentNi�os.Clear();

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
        foreach (TopoArbol1 ni�o in ni�os)
        {
            ni�o.StopGame();
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
            if (currentNi�os.Count <= (1))
            {
                // Choose a random mole.
                int index = Random.Range(0, ni�os.Count);
                // Doesn't matter if it's already doing something, we'll just try again next frame.
                if (!currentNi�os.Contains(ni�os[index]))
                {
                    currentNi�os.Add(ni�os[index]);
                    ni�os[index].Activate();
                }
            }
        }
    }

    public void AddScore(int ni�oIndex)
    {

        // Add and update score.
        score += 1;
        scoreText.text = $"{score}";
        // Increase time by a little bit.

        currentNi�os.Remove(ni�os[ni�oIndex]);
    }

    public void RemoveSCORE(int ni�oIndex)
    {
        score -= 2;
        scoreText.text = $"{score}";
        // Increase time by a little bit.

        currentNi�os.Remove(ni�os[ni�oIndex]);
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
        currentNi�os.Remove(ni�os[moleIndex]);
    }
}