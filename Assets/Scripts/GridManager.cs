using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject TilePrefab;
    public int gridRow;
    public int gridCol;
    public float Distance = 1.0f;

    int[,] valueArray;

    void SetValueArray()
    {
        for (int row = 0; row < gridRow; row++)
            for (int column = 0; column < gridCol; column++) // 2
            {
                valueArray[row, column] = Random.Range(1, 9);
            }
    }
    void SpawnGrid()
    {
        for (int row = 0; row < gridRow; row++)
            for (int column = 0; column < gridCol; column++) // 2
            {
                GameObject newTile = Instantiate(TilePrefab);
                newTile.GetComponent<PointManager>().pointValue = valueArray[row, column];
                newTile.GetComponent<PointManager>().pointX = row;
                newTile.GetComponent<PointManager>().pointY = column;
                newTile.name = row.ToString() + column.ToString();
                newTile.transform.parent = transform; // 6
                newTile.transform.position = transform.position + new Vector3(column * Distance, -row * Distance, 0); // 7
            }
    }
    void Start()
    {
        valueArray = new int[gridRow, gridCol];
        SetValueArray();
        SpawnGrid();
    }
}
