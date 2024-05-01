using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text movesTex;
    public TMP_Text HighScoreText;
    private void OnEnable()
    {
        scoreText.text = GameUtilityManager.instance.currentScore.ToString();
        movesTex.text = GameUtilityManager.instance.currentMoves.ToString();
    }
}
