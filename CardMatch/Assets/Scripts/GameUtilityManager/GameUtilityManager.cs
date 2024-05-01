/*
 * This script is responsible for handling game related common fields
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtilityManager : MonoBehaviour
{
    public static GameUtilityManager instance = null;
    public static GameUtilityManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public GameLevel _gameLevel;

    public string gameSceneName = "GamePlayScenes";
    public string menuSceneName = "MainMenuScene";

    public int currentScore;
    public int HighScore;

    public int currentMoves;


    private void OnEnable()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    public void LoadHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
    }
}

public enum GameLevel
{
    LEVEL_1,
    LEVEL_2,
    LEVEL_3,
    LEVEL_4
}