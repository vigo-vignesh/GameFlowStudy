using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour
{
    public static MenuSceneManager instance = null;
    public static MenuSceneManager Instance
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
    }

    public SplashScreenManager _SplashScreenManager;
    public LandingManager _landingScreenManager;
    public LevelManager _levelManager;


    private void Start()
    {
        _SplashScreenManager.gameObject.SetActive(true);
        _landingScreenManager.gameObject.SetActive(false);
        _levelManager.gameObject.SetActive(false);
    }
}
