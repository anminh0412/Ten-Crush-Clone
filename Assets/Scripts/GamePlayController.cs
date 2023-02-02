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

    [SerializeField] TextMeshProUGUI scoresText;
    int score = 0;
    public void GetPoint(int x, int y)
    {
        if(getFirstPoint == false)
        {
            firstPointX = x;
            firstPointY = y;
            point1 = GameObject.Find((firstPointX).ToString() + (firstPointY).ToString()).GetComponent<PointManager>();
            getFirstPoint = true;
        }
        else if (getFirstPoint == true)
        {
            lastPointX = x;
            lastPointY = y;
            point2 = GameObject.Find((lastPointX).ToString() + (lastPointY).ToString()).GetComponent<PointManager>();
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
                    bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
                    if(checkGoState)
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
                    bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX - i).ToString() + (firstPointY).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX + i).ToString() + (firstPointY).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX).ToString() + (firstPointY - i).ToString()).GetComponent<PointManager>().state;
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
                    bool checkGoState = GameObject.Find((firstPointX).ToString() + (firstPointY + i).ToString()).GetComponent<PointManager>().state;
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
            UpdateScore();
            point1.state = false;
            point2.state = false;
            point1.Satisfied();
            point2.Satisfied();
        }
        else 
        {
            Debug.Log("Khong hop le");
            point1.Checked();
            point2.Checked();
            return;
        }
    }

    void UpdateScore()
    {
        score += 10;
        scoresText.SetText(score.ToString());
    }
}
