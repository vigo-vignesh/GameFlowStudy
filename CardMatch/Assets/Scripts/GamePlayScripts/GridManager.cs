using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 4f)]
    private int rowCount;
    [SerializeField]
    [Range(2f, 4f)]
    private int coulmnCount;
    [SerializeField]
    private float cellSize;

    public int[,] gridConainer;

    private void Start()
    {
        GenerateGrid(rowCount, coulmnCount);
    }

    public void GenerateGrid(int height, int width)
    {
        this.rowCount = height;
        this.coulmnCount = width;

        gridConainer = new int[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Debug.Log(i + " , " + j);

                GameObject GridObj = Instantiate(GameManager.instance.GridElementTemplate) as GameObject;
                GridObj.transform.parent = transform;
                GridObj.transform.localScale = Vector3.one;
                GridObj.SetActive(true);
            }
        }

    }


}
