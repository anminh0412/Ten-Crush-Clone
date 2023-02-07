using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    [SerializeField] GameObject _content;
    [SerializeField] GetCurrentLevel getCurrentLevel;
    List<GameObject> _levelPrefab = new List<GameObject>();
    void Start()
    {
        _levelPrefab = getCurrentLevel.levelPrefabs;
        for (int i = 0; i < _levelPrefab.Count; i++)
        {
            GameObject go = Instantiate(_levelPrefab[i], new Vector3(0f, 0f, 0f), Quaternion.identity);
            go.transform.SetParent(_content.transform);
        }
    }

}
