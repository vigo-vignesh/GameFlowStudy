using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public static GameManager Instance
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
        //DontDestroyOnLoad(this.gameObject);
    }

    public GridElementManager _GridElementManager;

    public List<GridContainers> GridContainers = new List<GridContainers>();

    [SerializeField]
    private GridContainers _GridContainers;

    public GridManager _gridManager;

    private void OnEnable()
    {
        GameInitState();
    }

    void GameInitState()
    {
        _GridContainers = GridContainers[(int)GameUtilityManager.instance._gameLevel];
        SetGameEnvironment();
    }

    void SetGameEnvironment()
    {
        _gridManager.gameBG.sprite = _GridContainers.gameTypeBg;
        _GridElementManager.GridElementBg.sprite = _GridContainers.elementBg;
        _GridElementManager.GridElementCover.sprite = _GridContainers.elementCover;
        _GridElementManager.GridElementSpecialBg.sprite = _GridContainers.elementSpecialBg;
    }
}
[System.Serializable]
public class GridContainers
{
    public string levelName;
    public Sprite gameTypeBg;

    public Sprite elementBg;
    public Sprite elementCover;
    public Sprite elementSpecialBg;

    public List<Sprite> elementSprites;
}
