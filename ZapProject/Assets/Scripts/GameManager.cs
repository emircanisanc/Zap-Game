using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BallMovement ball;

    [SerializeField]
    private UIHandler uIHandler;

    private bool gameOver;

    void Awake()
    {
        uIHandler.setMenuInfos(PlayerPrefs.GetInt("gamesPlayed", 0), PlayerPrefs.GetInt("bestScore", 0));
    }

    public void startGame()
    {
        ball.enabled = true;
        PlayerPrefs.SetInt("gamesPlayed", PlayerPrefs.GetInt("gamesPlayed", 0) + 1);
        uIHandler.closeMenuScreen();
    }

    public void endGame(int currentScore)
    {
        gameOver = true;
        var bestScore = PlayerPrefs.GetInt("bestScore", 0);
        uIHandler.showGameOverScreen(bestScore, currentScore);
        if(bestScore < currentScore)
        {
             PlayerPrefs.SetInt("bestScore", currentScore);
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool isGameOver()
    {
        return gameOver;
    }

}
