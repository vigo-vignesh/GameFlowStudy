using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text movesTex;
    public TMP_Text HighScoreText;
    private void OnEnable()
    {
        scoreText.text = GameUtilityManager.instance.currentScore.ToString();
        movesTex.text = GameUtilityManager.instance.currentMoves.ToString();



        if (GameUtilityManager.instance.currentScore > GameUtilityManager.instance.HighScore)
        {
            GameUtilityManager.instance.HighScore = GameUtilityManager.instance.currentScore;
            GameUtilityManager.instance.LoadHighScore();
        }

        HighScoreText.text = GameUtilityManager.instance.HighScore.ToString();
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(GameUtilityManager.instance.menuSceneName);
    }
}
