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

    public List<GameObject> validationObj = new List<GameObject>();

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

        _gridManager.rowCount = _GridContainers.rowCount;
        _gridManager.coulmnCount = _GridContainers.coulmnCount;

        _gridManager.questionElementSprites = _GridContainers.elementSprites;

        //_gridManager.questionCount = _GridContainers.elementSprites.Count;
        _gridManager.GenerateGrid(_GridContainers.rowCount, _GridContainers.coulmnCount);
    }

    GameObject tempObjHolder = null;

    public IEnumerator ValidateAnswer(GameObject validationTest)
    {
        if (tempObjHolder == null)
        {
            tempObjHolder = validationTest;
        }
        else
        {
            if (validationTest.GetComponent<GridElementManager>().GridElementID == tempObjHolder.GetComponent<GridElementManager>().GridElementID)
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("wrong");
                yield return new WaitForSeconds(1f);
                validationTest.GetComponent<GridElementManager>().GridElementCover.gameObject.SetActive(true);
                tempObjHolder.GetComponent<GridElementManager>().GridElementCover.gameObject.SetActive(true);

            }

            tempObjHolder = null;
        }
    }
}
[System.Serializable]
public class GridContainers
{
    [Range(2f, 4f)]
    public int rowCount;

    [Range(2f, 6f)]
    public int coulmnCount;



    public string levelName;
    public Sprite gameTypeBg;

    public Sprite elementBg;
    public Sprite elementCover;
    public Sprite elementSpecialBg;

    public List<Sprite> elementSprites;
}
