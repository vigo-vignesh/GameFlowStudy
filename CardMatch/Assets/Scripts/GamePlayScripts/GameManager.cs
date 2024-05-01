using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public GameOverManager _GameOverManager;

    public List<GridContainers> GridContainers = new List<GridContainers>();

    [SerializeField]
    private GridContainers _GridContainers;

    public GridManager _gridManager;

    public List<GameObject> validationObj = new List<GameObject>();

    public TMP_Text scoreText;
    public TMP_Text scoreMovesText;

    public int scoreNum = 0;
    public int movesNum = 0;
    public int combos = 0;

    public AudioSource flipAudio;
    public AudioSource correctAudio;
    public AudioSource wrongAudio;
    public AudioSource gameOverAudio;


    private void OnEnable()
    {
        GameInitState();
    }

    void GameInitState()
    {
        scoreNum = 0;
        movesNum = 0;

        scoreText.text = scoreNum.ToString();
        scoreMovesText.text = movesNum.ToString();

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
        movesNum += 1;
        scoreMovesText.text = movesNum.ToString();

        if (tempObjHolder == null)
        {
            tempObjHolder = validationTest;
        }
        else
        {
            if (validationTest.GetComponent<GridElementManager>().GridElementID == tempObjHolder.GetComponent<GridElementManager>().GridElementID)
            {
                scoreNum += 10;
                scoreText.text = scoreNum.ToString();
                Debug.Log("Correct");

                correctAudio.Play();

                validationTest.SetActive(false);
                tempObjHolder.SetActive(false);
            }
            else
            {
                wrongAudio.Play();

                Debug.Log("wrong");
                yield return new WaitForSeconds(1f);
                validationTest.GetComponent<GridElementManager>().CloseCard();
                validationTest.GetComponent<GridElementManager>().GridElementCover.gameObject.SetActive(true);

                if (tempObjHolder != null)
                {
                    tempObjHolder.GetComponent<GridElementManager>().CloseCard();
                    tempObjHolder.GetComponent<GridElementManager>().GridElementCover.gameObject.SetActive(true);
                }
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
