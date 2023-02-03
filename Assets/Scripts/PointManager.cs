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
    public bool youAreTarget = false;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject button;
    [SerializeField] GameObject imageSatisfied;
    [SerializeField] GameObject imageSelect;
    [SerializeField] GameObject imageTarget;
    public GamePlayController gameManager;

    private void Start()
    {
        text.SetText(pointValue.ToString());
        if (youAreTarget) imageTarget.SetActive(true);
    }
    public void Satisfied()
    {
        button.SetActive(false);
        imageSelect.SetActive(false);
        imageSatisfied.SetActive(true);
        if (youAreTarget && gameManager != null) gameManager.CheckingLevelComplete(1);
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
