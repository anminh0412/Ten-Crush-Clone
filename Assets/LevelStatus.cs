using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStatus : MonoBehaviour
{
    public int _level;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _imgBg;
    [SerializeField] GameObject _imgIcon;
    [SerializeField] GameObject _lockArea;
    public bool _levelIsLock = true;

    public void UnlockLevel()
    {
        _levelIsLock = false;
        _imgBg.SetActive(false);
        _imgIcon.SetActive(false);
        _lockArea.SetActive(false);
    }
    private void Start()
    {
        _text.SetText(_level.ToString());
        if (_levelIsLock)
        {
            _imgBg.SetActive(true);
            _imgIcon.SetActive(true);
            _lockArea.SetActive(true);
        }
        else
        {
            _imgBg.SetActive(false);
            _imgIcon.SetActive(false);
            _lockArea.SetActive(false);
        }
    }
}
