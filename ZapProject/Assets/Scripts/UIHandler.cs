using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Text recordText;

    [SerializeField]
    private Text ScoreText;

    [SerializeField]
    private Text BestScoreText;

    [SerializeField]
    private GameObject gameOverScreenObject;

    [SerializeField]
    private Text bestScoreTextMenu;

    [SerializeField]
    private Text gamesPlayedTextMenu;

    [SerializeField]
    private GameObject menuObject;

    public void setRecord(int newRecord)
    {
        recordText.text = newRecord.ToString();
    }

    public void showGameOverScreen(int bestScore, int currentScore)
    {
        ScoreText.text = currentScore.ToString();
        BestScoreText.text = bestScore.ToString();
        gameOverScreenObject.SetActive(true);
    }

    public void closeMenuScreen()
    {
        menuObject.SetActive(false);
    }

    public void setMenuInfos(int gamesPlayed, int bestScore)
    {
        gamesPlayedTextMenu.text = gamesPlayed.ToString();
        bestScoreTextMenu.text = bestScore.ToString();
    }
}
