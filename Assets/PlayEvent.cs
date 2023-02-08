using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayEvent : MonoBehaviour
{
    public void OnClickPlay()
    {
        Invoke("ChangeScene", 0.25f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
