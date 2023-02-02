using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    public int pointX;
    public int pointY;
    public int pointValue;

    public bool state = true;

    [SerializeField] TextMeshPro text;
    [SerializeField] GameObject button;
    [SerializeField] GameObject imageSatisfied;
    [SerializeField] GameObject imageSelect;

    private void Start()
    {
        text.SetText(pointValue.ToString());
    }
    public void Satisfied()
    {
        button.SetActive(false);
        imageSelect.SetActive(false);
        imageSatisfied.SetActive(true);
    }
    public void Checked()
    {
        imageSelect.SetActive(false);
    }
    public void OnClickPoint()
    {
        imageSelect.SetActive(true);
        GameObject.Find("GameController").GetComponent<GamePlayController>().GetPoint(pointX, pointY);
    }
}
