using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public int[,] selectFirstPoint = new int[1,1];
    //Vi tri diem chon
    public int? firstPointX, firstPointY, lastPointX, lastPointY;
    bool getFirstPoint = false;

    //Field luu vi tri diem kha chon duoc tinh sau khi chon diem dau tien
    public void GetPoint(int x, int y)
    {
        if(getFirstPoint == false)
        {
            firstPointX = x;
            firstPointY = y;
            getFirstPoint = true;
        }
        else if (getFirstPoint == true)
        {
            lastPointX = x;
            lastPointY = y;
            Checking();
        }
    }
    
    void ResetPoint()
    {
        firstPointX = null;
        firstPointY = null;
        lastPointX = null;
        lastPointY = null;
        getFirstPoint = false;
    }

    void Checking()
    {
        Debug.Log("dang kiem tra logic");
        ResetPoint();
    }
}
