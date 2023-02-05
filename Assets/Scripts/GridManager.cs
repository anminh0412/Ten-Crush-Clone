using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject TilePrefab;
    public int gridRow;
    public int gridCol;
    public float Distance = 1.0f;
    GamePlayController _gamePlayController;

    [SerializeField] int _targetPoint;
    [SerializeField] int _11;
    [SerializeField] int _22;
    [SerializeField] int _33;
    [SerializeField] int _44;
    [SerializeField] int _55;
    [SerializeField] int _66;
    [SerializeField] int _77;
    [SerializeField] int _88;
    [SerializeField] int _99;
    [SerializeField] int _91;
    [SerializeField] int _82;
    [SerializeField] int _73;
    [SerializeField] int _64;
    int _1;
    int _2;
    int _3;
    int _4;
    int _5;
    int _6;
    int _7;
    int _8;
    int _9;

    int[,] valueArray;
    public PointManager[,] pointArray; 

    int arrayElements;
    int inputElements;
    int tempRow;
    int tempCol;
    int tempRow2;
    int tempCol2;

    void FixArraySize()
    {
        if (arrayElements > inputElements)
        {
            return;
        }
        else 
        { 
            gridRow += 1; 
            CalculationArraySize(); 
            FixArraySize(); 
        }
        
    }
    void CalculationArraySize()
    {
        arrayElements = gridCol * gridRow;
        inputElements = _1 + _2 + _3 + _4 + _5 + _6 + _7 + _8 + _9;
    }
    void CalculationNumber()
    {
        _1 = _11 * 2 + _91;
        _2 = _22 * 2 + _82;
        _3 = _33 * 2 + _73;
        _4 = _44 * 2 + _64;
        _5 = _55 * 2;
        _6 = _66 * 2 + _64;
        _7 = _77 * 2 + _73;
        _8 = _88 * 2 + _82;
        _9 = _99 * 2 + _91;
    }
    void SetValueArray()
    {
        valueArray = new int[gridRow, gridCol];
        pointArray = new PointManager[gridRow, gridCol];
        InputValueToRandomPosition(1, _1);
        InputValueToRandomPosition(2, _2);
        InputValueToRandomPosition(3, _3);
        InputValueToRandomPosition(4, _4);
        InputValueToRandomPosition(5, _5);
        InputValueToRandomPosition(6, _6);
        InputValueToRandomPosition(7, _7);
        InputValueToRandomPosition(8, _8);
        InputValueToRandomPosition(9, _9);
        InputValueToOrtherPosition();
    }
    void GetRandomPosition()
    {
        int row = Random.Range(0, gridRow);
        int col = Random.Range(0, gridCol);
        if (valueArray[row, col] == 0)
        {
            tempRow = row;
            tempCol = col;
        }
        else if (valueArray[row, col] != 0) GetRandomPosition();
    }
    void InputValueToRandomPosition(int number, int countOfNumber)
    {
        for (int i = 1; i <= countOfNumber; i++)
        {
           GetRandomPosition();
           valueArray[tempRow, tempCol] = number;
        }
        return;
    }
    void InputValueToOrtherPosition()
    {
        for (int row = 0; row < gridRow; row++)
            for (int column = 0; column < gridCol; column++)
            {
                if(valueArray[row, column] == 0)
                    valueArray[row, column] = Random.Range(1, 9);
            }
    }

    void SpawnGrid()
    {
        for (int row = 0; row < gridRow; row++)
            for (int column = 0; column < gridCol; column++) 
            {
                GameObject newTile = Instantiate(TilePrefab);
                pointArray[row, column] = newTile.GetComponent<PointManager>();
                pointArray[row, column].pointValue = valueArray[row, column];
                pointArray[row, column].pointX = row;
                pointArray[row, column].pointY = column;
                newTile.name = row.ToString() + column.ToString();
                newTile.transform.parent = transform; 
                newTile.transform.position = transform.position + new Vector3(column * Distance, -row * Distance, 0);
                
            }
    }
    void GetRandomPositionToSetTargetPoint()
    {
        int row = Random.Range(0, gridRow);
        int col = Random.Range(0, gridCol);
        //PointManager tempPoint = GameObject.Find(row.ToString() + col.ToString()).GetComponent<PointManager>();
        PointManager tempPoint = pointArray[row, col];
        if (tempPoint.youAreTarget == false)
        {
            tempRow2 = row;
            tempCol2 = col;
            return;
        }
        else 
        {
            GetRandomPositionToSetTargetPoint();
        }
    }
    void SetTargetPoint()
    {
        gameObject.GetComponent<GamePlayController>().targetPoint = _targetPoint;
        if (_targetPoint > arrayElements) _targetPoint = arrayElements;
        for (int i = 1; i <= _targetPoint; i++)
        {
            GetRandomPositionToSetTargetPoint();
            //PointManager tempPoint = GameObject.Find(tempRow2.ToString() + tempCol2.ToString()).GetComponent<PointManager>();
            PointManager tempPointManager = pointArray[tempRow2, tempCol2];
            tempPointManager.youAreTarget = true;
            tempPointManager.gameManager = gameObject.GetComponent<GamePlayController>();
        }
    }
    public void CheckEmptyCol(int _col)
    {
        for(int i = 0; i < gridRow; i++)
        {
            if (pointArray[i,_col].state == true)
            {
                return;
            }
        }
        for (int i = 0; i < gridRow; i++)
        {
            pointArray[i, _col].DestroyEvent();
        }

        for (int i = 0; i < gridRow; i++)
            for (int j = _col; j < gridCol - 1; j++)
            {
                pointArray[i, j] = pointArray[i,j + 1];
                pointArray[i, j].transform.position += new Vector3(-Distance, 0, 0);
                pointArray[i, j].pointY -= 1;
            }
        gridCol -= 1;
        _gamePlayController.UpdateScore(gridRow * 10);
    }
    public void CheckEmptyRow(int _row)
    {
        for (int i = 0; i < gridCol; i++)
        {
            if (pointArray[_row,i].state == true)
            {
                return;
            }
        }
        for (int i = 0; i < gridCol; i++)
        {
            pointArray[_row, i].DestroyEvent();
        }
        for (int i = _row; i < gridRow - 1; i++)
            for (int j = 0; j < gridCol; j++)
            {
                pointArray[i,j] = pointArray[i + 1,j]; 
                pointArray[i, j].transform.position += new Vector3(0, Distance, 0);
                pointArray[i, j].pointX -= 1;
            }
        gridRow -= 1;
        _gamePlayController.UpdateScore(gridCol * 10);
    }
    void Start()
    {
        _gamePlayController = gameObject.GetComponent<GamePlayController>();
        CalculationNumber();
        CalculationArraySize();
        FixArraySize();
        SetValueArray();
        SpawnGrid();
        SetTargetPoint();
    }
}
