using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private BallMovement ball;

    [SerializeField]
    private UIHandler uIHandler;

    [SerializeField]
    private PlatformColorController platformColorController;

    private bool gameOver;
    private bool gameStarted;

    private float sound;

    [SerializeField]
    private int frameRate = 60;


    void Awake()
    {
        uIHandler.setMenuInfos(PlayerPrefs.GetInt("gamesPlayed", 0), PlayerPrefs.GetInt("bestScore", 0));
        sound = PlayerPrefs.GetFloat("soundVolume", 1);
        AudioListener.volume = sound;
        refreshSoundImage();
        Application.targetFrameRate = frameRate;
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
        gameStarted = true;
        ball.enabled = true;
        PlayerPrefs.SetInt("gamesPlayed", PlayerPrefs.GetInt("gamesPlayed", 0) + 1);
        uIHandler.closeMenuScreen();
        platformColorController.startChangingColor();
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

    public bool isGameStarted(){
        return gameStarted;
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
