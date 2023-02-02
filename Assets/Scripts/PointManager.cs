using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int pointX;
    public int pointY;
    public int pointValue;

    bool state = true;

    [SerializeField] TextMeshPro text;

    private void Start()
    {
        text.SetText(pointValue.ToString());
    }

    public void OnClickPoint()
    {
        GameObject.Find("GameController").GetComponent<GamePlayController>().GetPoint(pointX, pointY);
    }
}
