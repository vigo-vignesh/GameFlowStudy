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
        GridElementCover.gameObject.SetActive(false);

        StartCoroutine(GameManager.instance.ValidateAnswer(gameObject));
    }
}
