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

    private float sound;

    void Awake()
    {
        uIHandler.setMenuInfos(PlayerPrefs.GetInt("gamesPlayed", 0), PlayerPrefs.GetInt("bestScore", 0));
        sound = PlayerPrefs.GetFloat("soundVolume", 1);
        AudioListener.volume = sound;
        refreshSoundImage();
    }

    private void refreshSoundImage(){
        if(sound == 1){
            uIHandler.setSoundOnOffImage(true);
        }else{
            uIHandler.setSoundOnOffImage(false);
        }
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

    public void toggleSound(){
        if(sound == 1){
            sound = 0;
            PlayerPrefs.SetFloat("soundVolume", 0);
            AudioListener.volume = sound;
            refreshSoundImage();
        }else{
            sound = 1;
            PlayerPrefs.SetFloat("soundVolume", 1);
            AudioListener.volume = sound;
            refreshSoundImage();
        }
        GUI.FocusControl(null);
    }
}
