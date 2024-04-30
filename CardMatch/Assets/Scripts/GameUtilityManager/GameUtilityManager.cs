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
}

public enum GameLevel
{
    LEVEL_1,
    LEVEL_2, 
    LEVEL_3
}