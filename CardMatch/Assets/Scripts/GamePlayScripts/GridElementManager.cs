/*
 * This script is responsible for handling game Grid operations
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridElementManager : MonoBehaviour
{
    public Image GridElementBg;
    public Image GridElementCover;
    public Image GridElementSpecialBg;
    public Image GridElement;

    public int GridElementID;
    public void OpenElement()
    {
        OpenCard();

        GameManager.instance.flipAudio.Play();

        StartCoroutine(GameManager.instance.ValidateAnswer(gameObject));
    }
    public void OpenCard()
    {
        iTween.RotateTo(GridElementCover.gameObject, iTween.Hash("y", -90f, "time", 0.5f, "oncomplete", "SetObjFalse", "oncompletetarget",transform.gameObject));
    }
    public void CloseCard()
    {
        GridElementCover.gameObject.SetActive(true);
        GridElementCover.transform.localRotation = Quaternion.Euler(GridElementCover.transform.localRotation.x,-90f, GridElementCover.transform.localRotation.z);
        iTween.RotateTo(GridElementCover.gameObject, iTween.Hash("y", 0f, "time", 0.5f));
    }

    void SetObjFalse()
    {
        GridElementCover.gameObject.SetActive(false);
    }

    public void CloseGridElement()
    {
        GridElementBg.gameObject.SetActive(false);
        GridElementCover.gameObject.SetActive(false);
    }
}
