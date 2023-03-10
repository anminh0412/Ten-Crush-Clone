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
    public bool youAreSuggest = false;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject button;
    [SerializeField] GameObject imageBg;
    [SerializeField] GameObject imageSatisfied;
    [SerializeField] GameObject imageSelect;
    [SerializeField] GameObject imageTarget;
    [SerializeField] GameObject imageSuggest;
    public GamePlayController gameManager;
    public GridManager _gridManager;

    private void Start()
    {
        text.SetText(pointValue.ToString());
        if (youAreTarget) 
        {
            imageTarget.SetActive(true);
            imageBg.SetActive(false);
        } 
    }
    public void Satisfied()
    {
        state = false;
        button.SetActive(false);
        imageSelect.SetActive(false);
        imageSatisfied.SetActive(true);
        if (youAreTarget && gameManager != null) gameManager.CheckingLevelComplete(1);
        if (youAreSuggest && _gridManager != null)
        {
            _gridManager.currentWaitingTime = _gridManager.waitingTime;
            _gridManager.suggested = false;
        }
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
    public void SuggestPoint()
    {
        imageSuggest.SetActive(true);
        youAreSuggest = true;
    }
    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
