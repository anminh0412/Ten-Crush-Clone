using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLevelToPlay : MonoBehaviour
{
    //Level List
    public List<GameObject> levelPrefabs = new List<GameObject>();
    public int currentLevel;
    //Level Config
    public int _gridRow;
    public int _gridCol;
    public int _targetPoint;
    public int _11;
    public int _22;
    public int _33;
    public int _44;
    public int _55;
    public int _66;
    public int _77;
    public int _88;
    public int _99;
    public int _91;
    public int _82;
    public int _73;
    public int _64;

    public void GetSceneManager(GameObject level)
    {
        LevelInfo _nextLevel = level.GetComponent<LevelInfo>();
        GetNextLevelConfig(_nextLevel);
    }
    public void GetLevelList(List<GameObject> _levelList)
    {
        levelPrefabs = _levelList;
    }
    public void GetCurrentLevel(int _currentLevel)
    {
        currentLevel = _currentLevel;
    }
    public void GetNextLevelInfo()
    {
        currentLevel += 1;
        GameObject _nextLevel = levelPrefabs[currentLevel];
        GetNextLevelConfig(_nextLevel.GetComponent<LevelInfo>());
        _nextLevel.GetComponent<LevelStatus>().UnlockLevel();
    }
    void GetNextLevelConfig(LevelInfo nextLevel)
    {
        _gridRow = nextLevel.gridRow;
        _gridCol = nextLevel.gridCol;
        _targetPoint = nextLevel._targetPoint;
        _11 = nextLevel._11;
        _22 = nextLevel._22;
        _33 = nextLevel._33;
        _44 = nextLevel._44;
        _55 = nextLevel._55;
        _66 = nextLevel._66;
        _77 = nextLevel._77;
        _88 = nextLevel._88;
        _99 = nextLevel._99;
        _91 = nextLevel._91;
        _82 = nextLevel._82;
        _73 = nextLevel._73;
        _64 = nextLevel._64;
    }
    public void SendLevelConfigInfo(GridManager gridManager)
    {
        gridManager.ConfigGame(_gridRow, _gridCol, _targetPoint, _11, _22, _33, _44, _55, _66, _77, _88, _99, _91, _82, _73, _64);
    }
}
