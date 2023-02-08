using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelCanvasButtonController : MonoBehaviour
{
    [SerializeField] GameObject PausePanel;
    GetLevelToPlay getLevelToPlay;
    private void Start()
    {
        getLevelToPlay = GameObject.FindGameObjectWithTag("GrabLevelInfo").GetComponent<GetLevelToPlay>();
    }
    public void OnClickPause()
    {
        PausePanel.SetActive(true);
    }
    public void OnClickResume()
    {
        PausePanel.SetActive(false);
    }
    public void OnClickReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void OnClickNextLevel()
    {
        Debug.Log("next level");
        getLevelToPlay.GetNextLevelInfo();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void OnClickIndexMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
