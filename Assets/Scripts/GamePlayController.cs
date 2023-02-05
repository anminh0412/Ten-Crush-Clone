using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayController : MonoBehaviour
{
    public int[,] selectFirstPoint = new int[1,1];
    public int? firstPointX, firstPointY, lastPointX, lastPointY;
    bool getFirstPoint = false;
    PointManager point1;
    PointManager point2;
    GridManager gird;

    [SerializeField] TextMeshProUGUI scoresText;
    [SerializeField] GameObject winPanel;
    int score = 0;
    public int currentPoint = 0;
    public int targetPoint;

    private void Start()
    {
        gird = gameObject.GetComponent<GridManager>();
    }
    public void GetPoint(int x, int y)
    {
        if(getFirstPoint == false)
        {
            firstPointX = x;
            firstPointY = y;
            //point1 = GameObject.Find((firstPointX).ToString() + (firstPointY).ToString()).GetComponent<PointManager>();
            point1 = gird.pointArray[(int)firstPointX, (int)firstPointY];
            getFirstPoint = true;
        }
        else if (getFirstPoint == true)
        {
            lastPointX = x;
            lastPointY = y;
            //point2 = GameObject.Find((lastPointX).ToString() + (lastPointY).ToString()).GetComponent<PointManager>();
            point2 = gird.pointArray[(int)lastPointX, (int)lastPointY];
            Checking();
        }
    }
    
    void ResetPoint()
    {
        firstPointX = null;
        firstPointY = null;
        lastPointX = null;
        lastPointY = null;
        point1 = null;
        point2 = null;
        getFirstPoint = false;
    }

    void Checking()
    {
        int? checkX = firstPointX - lastPointX;
        int? checkY = firstPointY - lastPointY;

        if(checkX != 0 && checkY != 0)
        {
            int? temp = checkX / checkY;
            if(temp != 1 && temp != -1)
            {
                Debug.Log("diem chon khong hop le!!!");
                point1.Checked();
                point2.Checked();
                ResetPoint();
                return;
            }
        }
        
        if(checkX > 0)
        {
            if(checkY > 0)
            {
                //Debug.Log("trai tren");
                for (int? i = 1; i < checkX; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX - i), (int)(firstPointY - i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
            else if(checkY < 0)
            {
                //Debug.Log("phai tren");
                for (int? i = 1; i < checkX; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX - i), (int)(firstPointY + i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
            else if (checkY == 0)
            {
                //Debug.Log("tren");
                for (int? i = 1; i < checkX; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX - i), (int)firstPointY].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
        }
        else if(checkX < 0)
        {
            if (checkY > 0)
            {
                //Debug.Log("trai duoi");
                for (int? i = 1; i < checkY; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX + i), (int)(firstPointY - i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
            else if (checkY < 0)
            {
                //Debug.Log("phai duoi");
                for (int? i = 1; i < -checkY; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX + i), (int)(firstPointY + i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
            else if (checkY == 0)
            {
                //Debug.Log("duoi");
                for (int? i = 1; i < -checkX; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX + i), (int)(firstPointY)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
        }
        else if( checkX == 0)
        {
            if (checkY > 0)
            {
                //Debug.Log("trai ");
                for (int? i = 1; i < checkY; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX), (int)(firstPointY - i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
            else if (checkY < 0)
            {
                //Debug.Log("phai");
                for (int? i = 1; i < -checkY; i++)
                {
                    //Debug.Log("dang tim" + (firstPointX - i).ToString() + (firstPointY - i).ToString());
                    //bool checkGoState = GameObject.Find((firstPointX).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
                    bool checkGoState = gird.pointArray[(int)(firstPointX), (int)(firstPointY + i)].state;
                    if (checkGoState)
                    {
                        Debug.Log("Duong di da bi chan");
                        point1.Checked();
                        point2.Checked();
                        ResetPoint();
                        return;
                    }
                }
                CheckingValue();
                ResetPoint();
            }
        }
    }
    void CheckingValue()
    {
        if (point1.pointValue == point2.pointValue || point1.pointValue + point2.pointValue == 10)
        {
            Debug.Log("Hop le");
            UpdateScore(10);
            point1.Satisfied();
            point2.Satisfied();
            if(point1.pointX == point2.pointX)
            {
                gird.CheckEmptyRow(point1.pointX);
                gird.CheckEmptyCol(point1.pointY);
                gird.CheckEmptyCol(point2.pointY);
            }
            else if (point1.pointY == point2.pointY)
            {
                gird.CheckEmptyCol(point1.pointY);
                gird.CheckEmptyRow(point1.pointX);
                gird.CheckEmptyRow(point2.pointX);
            }
            else
            {
                gird.CheckEmptyCol(point1.pointY);
                gird.CheckEmptyCol(point2.pointY);
                gird.CheckEmptyRow(point1.pointX);
                gird.CheckEmptyRow(point2.pointX);
            }
        }
        else 
        {
            Debug.Log("Khong hop le");
            point1.Checked();
            point2.Checked();
            return;
        }
    }
    public void UpdateScore(int _score)
    {
        score += _score;
        scoresText.SetText(score.ToString());
    }
    public void CheckingLevelComplete(int _getPoint)
    {
        currentPoint += _getPoint;
        if(currentPoint >= targetPoint)
        {
            LevelCompleted();
        }
    }
    void LevelCompleted()
    {
        winPanel.SetActive(true);
    }
}
