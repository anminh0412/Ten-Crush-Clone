using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject MenuPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject LevelPanel;
    GameObject currentPanel;
    public void OnClickSetting()
    {
        UpdateCurrenPanel(SettingPanel);
        SettingPanel.SetActive(true);
    }
    public void OnClickLevel()
    {
        UpdateCurrenPanel(LevelPanel);
        LevelPanel.SetActive(true);
    }
    public void OnClickBackToMenu()
    {
        UpdateCurrenPanel(MenuPanel);
        MenuPanel.SetActive(true);
    }
    void UpdateCurrenPanel(GameObject _goPanel)
    {
        currentPanel.SetActive(false);
        currentPanel = _goPanel;
    }
    private void Start()
    {
        currentPanel = MenuPanel;
    }
}
