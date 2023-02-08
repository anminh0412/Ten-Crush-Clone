using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetCurrentLevel : MonoBehaviour
{
    public int levelMaxUnlock;
    [SerializeField] TextMeshProUGUI levelText;
    public List<GameObject> levelPrefabs = new List<GameObject>();
    GetLevelToPlay getLevelToPlay;
    MenuManager menuManager;
    
    void FindUnlockLevel()
    {
        for (int i = 0; i <= levelPrefabs.Count; i++)
        {
            if (levelPrefabs[i].GetComponent<LevelStatus>()._levelIsLock == false)
            {
                levelMaxUnlock = i;
            }
            else return;
        }
    }
    public void ChangeCurrentLevel(int _currentlevel)
    {
        levelText.SetText((_currentlevel + 1).ToString());
        getLevelToPlay.GetSceneManager(levelPrefabs[_currentlevel]);
        getLevelToPlay.GetCurrentLevel(_currentlevel);
        menuManager.OnClickBackToMenu();
    }
    private void Start()
    {
        menuManager = GetComponent<MenuManager>();
        getLevelToPlay = GameObject.FindGameObjectWithTag("GrabLevelInfo").GetComponent<GetLevelToPlay>();
        FindUnlockLevel();
        getLevelToPlay.GetSceneManager(levelPrefabs[levelMaxUnlock]);
        getLevelToPlay.GetLevelList(levelPrefabs);
        getLevelToPlay.GetCurrentLevel(levelMaxUnlock);
        levelText.SetText((levelMaxUnlock + 1).ToString());
    }
}
