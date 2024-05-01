using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string level)
    {
        switch (level)
        {
            case "Level_1":
                GameUtilityManager.instance._gameLevel = GameLevel.LEVEL_1;
                break;
            case "Level_2":
                GameUtilityManager.instance._gameLevel = GameLevel.LEVEL_2;
                break;
            case "Level_3":
                GameUtilityManager.instance._gameLevel = GameLevel.LEVEL_3;
                break;
            case "Level_4":
                GameUtilityManager.instance._gameLevel = GameLevel.LEVEL_4;
                break;
        }

        SceneManager.LoadScene(GameUtilityManager.instance.gameSceneName);
    }

    public void BackButtonAction()
    {
        MenuSceneManager.instance._levelManager.gameObject.SetActive(false);
        MenuSceneManager.instance._landingScreenManager.gameObject.SetActive(true);
    }
}
