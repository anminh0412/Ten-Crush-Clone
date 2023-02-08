using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerConfigGame : MonoBehaviour
{
    GetLevelToPlay getLevelToPlay;
    GridManager gridManager;
    private void OnEnable()
    {
        getLevelToPlay = this.gameObject.GetComponent<GetLevelToPlay>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            gridManager = GameObject.FindGameObjectWithTag("SpawnGame").GetComponent<GridManager>();
            getLevelToPlay.SendLevelConfigInfo(gridManager);
        }
    }
}
