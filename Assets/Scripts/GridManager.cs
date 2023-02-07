using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridManager : MonoBehaviour
{
    public GameObject TilePrefab;
    public GameObject configCanvat;
    public int gridRow;
    public int gridCol;
    public float Distance = 1.0f;
    GamePlayController _gamePlayController;
    public float waitingTime;
    public float currentWaitingTime;
    public bool suggested = false;
    bool gameStated = false;
    [SerializeField] float _padding = 0.5f;

    [SerializeField] RectTransform rt;

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


    [SerializeField] TMP_InputField _TtargetPoint;
    [SerializeField] TMP_InputField _TgridRow;
    [SerializeField] TMP_InputField _TgridCol;
    [SerializeField] TMP_InputField _T11;
    [SerializeField] TMP_InputField _T22;
    [SerializeField] TMP_InputField _T33;
    [SerializeField] TMP_InputField _T44;
    [SerializeField] TMP_InputField _T55;
    [SerializeField] TMP_InputField _T66;
    [SerializeField] TMP_InputField _T77;
    [SerializeField] TMP_InputField _T88;
    [SerializeField] TMP_InputField _T99;
    [SerializeField] TMP_InputField _T91;
    [SerializeField] TMP_InputField _T82;
    [SerializeField] TMP_InputField _T73;
    [SerializeField] TMP_InputField _T64;

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
    List<PointManager> checkedList = new List<PointManager>();
    List<PointManager> checkedActiveList;
    List<bool> checkedGameOver = new List<bool>();

    int arrayElements;
    int inputElements;
    int tempRow;
    int tempCol;
    int tempRow2;
    int tempCol2;

    public void ConfigGame()
    {
        //Debug.Log(_TgridRow.text);
        if (_TgridRow.text == "") gridRow = 5; else gridRow = int.Parse(_TgridRow.text);
        if (_TgridCol.text == "") gridCol = 5; else gridCol = int.Parse(_TgridCol.text);
        if (_T11.text == "") _11 = 0; else _11 = int.Parse(_T11.text);
        if (_T22.text == "") _22 = 0; else _22 = int.Parse(_T22.text);
        if (_T33.text == "") _33 = 0; else _33 = int.Parse(_T33.text);
        if (_T44.text == "") _44 = 0; else _44 = int.Parse(_T44.text);
        if (_T55.text == "") _55 = 0; else _55 = int.Parse(_T55.text);
        if (_T66.text == "") _66 = 0; else _66 = int.Parse(_T66.text);
        if (_T77.text == "") _77 = 0; else _77 = int.Parse(_T77.text);
        if (_T88.text == "") _88 = 0; else _88 = int.Parse(_T88.text);
        if (_T99.text == "") _99 = 0; else _99 = int.Parse(_T99.text);
        if (_T91.text == "") _91 = 0; else _91 = int.Parse(_T91.text);
        if (_T82.text == "") _82 = 0; else _82 = int.Parse(_T82.text);
        if (_T73.text == "") _73 = 0; else _73 = int.Parse(_T73.text);
        if (_T64.text == "") _64 = 0; else _64 = int.Parse(_T64.text);
        if (_TtargetPoint.text == "") _targetPoint = 5; else _targetPoint = int.Parse(_TtargetPoint.text);
        configCanvat.SetActive(false);
        GameStart();
    }
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
        rt.sizeDelta = new Vector2(gridCol + _padding * 2f, gridRow + _padding * 2f);
        for (int row = 0; row < gridRow; row++)
            for (int column = 0; column < gridCol; column++) 
            {
                GameObject newTile = Instantiate(TilePrefab);
                pointArray[row, column] = newTile.GetComponent<PointManager>();
                pointArray[row, column].pointValue = valueArray[row, column];
                pointArray[row, column].pointX = row;
                pointArray[row, column].pointY = column;
                pointArray[row, column]._gridManager = gameObject.GetComponent<GridManager>();
                newTile.name = row.ToString() + column.ToString();
                newTile.transform.parent = transform; 
                newTile.transform.position = transform.position + new Vector3(transform.position.x - gridCol / 2f, transform.position.y + gridRow/2f, 0f) + new Vector3(column * Distance, -row * Distance, 0f);
                checkedList.Add(pointArray[row, column]);
            }
        checkedActiveList = new List<PointManager>(checkedList);

        rt.position = new Vector3(gridCol / 2f - 4f, -(gridRow / 2f - 7f), 0f);
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
    void RandomSuggest()
    {
        suggested = true;
        if (checkedActiveList.Count <= 0)
        {
            return;
        }
        int listIndex = Random.Range(0, checkedActiveList.Count - 1);
        PointManager _pManager = checkedActiveList[listIndex];
        int row = _pManager.pointX;
        int col = _pManager.pointY;
        checkedActiveList.RemoveAt(listIndex);
        FindPointSatisfied(row,col);
    }
    void FindPointSatisfied(int _findX, int _findY)
    {
        //tren
        for (int i = _findX - 1; i >= 0; i--)
        {
            if (pointArray[i, _findY].state == true)
            {
                if (pointArray[i, _findY].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(i, _findY, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //duoi
        for (int i = _findX + 1; i < gridRow; i++)
        {
            if (pointArray[i, _findY].state == true)
            {
                if (pointArray[i, _findY].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(i, _findY, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai
        for (int j = _findY + 1; j < gridCol; j++)
        {
            if (pointArray[_findX, j].state == true)
            {
                if (pointArray[_findX, j].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX, j, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai
        for (int j = _findY - 1; j >= 0; j--)
        {
            if (pointArray[_findX, j].state == true)
            {
                if (pointArray[_findX, j].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX, j, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai tren
        for (int i = 1; i >= 0; i++)
        {
            if (_findX - i <= 0 || _findY - i <= 0)
            {
                break;
            }
            if (pointArray[_findX - i, _findY - i].state == true)
            {
                if (pointArray[_findX - i, _findY - i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX - i, _findY - i, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai tren
        for (int i = 1; i >= 0; i++)
        {
            if(_findX - i <= 0|| _findY + i >= gridCol - 1)
            {
                break;
            }
            if (pointArray[_findX - i, _findY + i].state == true)
            {
                if (pointArray[_findX - i, _findY + i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX - i, _findY + i, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai duoi
        for (int i = 1; i >= 0; i++)
        {
            if (_findX + i >= gridRow - 1 || _findY - i <= 0)
            {
                break;
            }
            if (pointArray[_findX + i, _findY - i].state == true)
            {
                if (pointArray[_findX + i, _findY - i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX + i, _findY - i, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai duoi
        for (int i = 1; i >= 0; i++)
        {
            if (_findX + i >= gridRow - 1 || _findY + i >= gridCol - 1)
            {
                break;
            }
            if (pointArray[_findX + i, _findY + i].state == true)
            {
                if (pointArray[_findX + i, _findY + i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    FinderPoint(_findX + i, _findY + i, _findX, _findY);
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        currentWaitingTime = waitingTime;
        suggested = false;
        RandomSuggest();
    }
    void FinderPoint(int _row1, int _col1, int _row2, int _col2)
    {
        pointArray[_row1, _col1].SuggestPoint();
        pointArray[_row2, _col2].SuggestPoint();
    }
    public void CheckGameOver()
    {
        for (int i = 0; i < checkedList.Count; i++)
        {
            CheckingGameOver(checkedList[i].pointX, checkedList[i].pointY);
        }
        if(checkedGameOver.Count == checkedList.Count)
        {
            _gamePlayController.LevelLoss();
        }
        else checkedGameOver.Clear();
    }
    void CheckingGameOver(int _findX, int _findY)
    {
        for (int i = _findX - 1; i >= 0; i--)
        {
            if (pointArray[i, _findY].state == true)
            {
                if (pointArray[i, _findY].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //duoi
        for (int i = _findX + 1; i < gridRow; i++)
        {
            if (pointArray[i, _findY].state == true)
            {
                if (pointArray[i, _findY].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai
        for (int j = _findY + 1; j < gridCol; j++)
        {
            if (pointArray[_findX, j].state == true)
            {
                if (pointArray[_findX, j].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai
        for (int j = _findY - 1; j >= 0; j--)
        {
            if (pointArray[_findX, j].state == true)
            {
                if (pointArray[_findX, j].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai tren
        for (int i = 1; i >= 0; i++)
        {
            if (_findX - i <= 0 || _findY - i <= 0)
            {
                break;
            }
            if (pointArray[_findX - i, _findY - i].state == true)
            {
                if (pointArray[_findX - i, _findY - i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai tren
        for (int i = 1; i >= 0; i++)
        {
            if (_findX - i <= 0 || _findY + i >= gridCol - 1)
            {
                break;
            }
            if (pointArray[_findX - i, _findY + i].state == true)
            {
                if (pointArray[_findX - i, _findY + i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //trai duoi
        for (int i = 1; i >= 0; i++)
        {
            if (_findX + i >= gridRow - 1 || _findY - i <= 0)
            {
                break;
            }
            if (pointArray[_findX + i, _findY - i].state == true)
            {
                if (pointArray[_findX + i, _findY - i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        //phai duoi
        for (int i = 1; i >= 0; i++)
        {
            if (_findX + i >= gridRow - 1 || _findY + i >= gridCol - 1)
            {
                break;
            }
            if (pointArray[_findX + i, _findY + i].state == true)
            {
                if (pointArray[_findX + i, _findY + i].pointValue == pointArray[_findX, _findY].pointValue)
                {
                    return;
                }
                else
                {
                    break;
                }
            }
        }
        checkedGameOver.Add(true);
    }
    void GameStart()
    {
        _gamePlayController = gameObject.GetComponent<GamePlayController>();
        CalculationNumber();
        CalculationArraySize();
        FixArraySize();
        SetValueArray();
        SpawnGrid();
        SetTargetPoint();
        currentWaitingTime = waitingTime;
        gameStated = true;
    }
    private void Update()
    {
        if (gameStated == false) return;
        currentWaitingTime -= Time.deltaTime;
        if (currentWaitingTime <= 0f && !suggested)
        {
            RandomSuggest();
        }
    }
    private void FixedUpdate()
    {
        if (gameStated == false) return;
        for (int i = 0; i <= checkedList.Count - 1; i++)
        {
            if (checkedList[i].state == false) 
            { 
                checkedList.RemoveAt(i);
                checkedActiveList = new List<PointManager>(checkedList);
            }
        }
        Debug.Log("curren array count" + checkedActiveList.Count);
        /*if(checkedActiveList.Count <= 0)
        {
            _gamePlayController.LevelLoss();
        }*/
    }
}
