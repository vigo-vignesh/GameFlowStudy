using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField]
    private float loadTime;
    private void Start()
    {
        Invoke("LoadNextScene", loadTime);
    }

    void LoadNextScene()
    {
        MenuSceneManager.instance._SplashScreenManager.gameObject.SetActive(false);
        MenuSceneManager.instance._landingScreenManager.gameObject.SetActive(true);
    }
}
