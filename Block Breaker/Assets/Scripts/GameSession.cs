using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Configuration parameters
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f; // Adjusts game speed
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    // State Variables
    [SerializeField] int currentScore = 0;

    // Implementing a singleton pattern
    private void Awake()
    {
        // Finding the number of GameObject
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;

        // If a GameObject already exists, destroy the newly created one
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    void Start()
    {
        // Initialized the score of on startup to 0 and displays it
        scoreText.text = currentScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        scoreText.text = currentScore.ToString();
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }

    // Resets the game object
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
