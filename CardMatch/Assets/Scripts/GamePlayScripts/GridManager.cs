using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public int rowCount;

    public int coulmnCount;

    [SerializeField]
    private float cellSize;

    public Image gameBG;
    public List<Sprite> questionElementSprites;

    public List<Sprite> pickedQuestion;

    public List<GameObject> questionsGenerated = new List<GameObject>();

    public int questionCount;

    public void GenerateGrid(int height, int width)
    {
        this.rowCount = height;
        this.coulmnCount = width;

        transform.GetComponent<GridLayoutGroup>().constraintCount = coulmnCount;

        reshuffle(questionElementSprites);
        questionCount = questionElementSprites.Count;
        pickQuestion(questionCount);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                GameObject GridObj = Instantiate(GameManager.instance._GridElementManager.gameObject) as GameObject;
                GridObj.transform.parent = transform;
                GridObj.transform.localScale = Vector3.one;

                GridObj.SetActive(true);

                questionsGenerated.Add(GridObj);
            }
        }

        SetQuestions();
    }

    void SetQuestions()
    {
        Debug.Log("questionCount " + transform.childCount);

        for (int i = 0; i < transform.childCount / 2; i++)
        {
            switch (i)
            {
                case 0:
                    for (int j = 0; j < coulmnCount; j++)
                    {
                        Debug.Log("Expect i " + i);
                        Debug.Log("Expect j " + j);

                        questionsGenerated[i + j].GetComponent<GridElementManager>().GridElementID = j;
                        questionsGenerated[i + j].GetComponent<GridElementManager>().GridElement.sprite = pickedQuestion[j];
                    }
                    break;
                case 1:
                    for (int j = 0; j < coulmnCount; j++)
                    {
                        Debug.Log("Expect i " + i);
                        Debug.Log("Expect j " + j);

                        questionsGenerated[j + coulmnCount].GetComponent<GridElementManager>().GridElementID = j;
                        questionsGenerated[j + coulmnCount].GetComponent<GridElementManager>().GridElement.sprite = pickedQuestion[j];
                    }
                    break;
                case 2:
                    for (int j = 0; j < coulmnCount; j++)
                    {
                        Debug.Log("Expect i " + i);
                        Debug.Log("Expect j " + j);

                        questionsGenerated[j + coulmnCount].GetComponent<GridElementManager>().GridElementID = j;
                        questionsGenerated[j + coulmnCount].GetComponent<GridElementManager>().GridElement.sprite = pickedQuestion[j];
                    }
                    break;
                default:
                    break;
            }

        }

    }

    void reshuffle(List<Sprite> elementSprites)
    {
        for (int t = 0; t < elementSprites.Count; t++)
        {
            Sprite tmp = elementSprites[t];
            int r = Random.Range(t, elementSprites.Count);
            elementSprites[t] = elementSprites[r];
            elementSprites[r] = tmp;
        }
    }

    void pickQuestion(int questionCount)
    {
        for (int i = 0; i < questionCount; i++)
        {
            pickedQuestion.Add(questionElementSprites[i]);
        }
    }
}
