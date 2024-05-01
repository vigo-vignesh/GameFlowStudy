using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingManager : MonoBehaviour
{
    public void LoadGameAction()
    {
       MenuSceneManager.instance._landingScreenManager.gameObject.SetActive(false);
        MenuSceneManager.instance._levelManager.gameObject.SetActive(true);
    }
}
