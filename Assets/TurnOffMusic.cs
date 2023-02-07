using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffMusic : MonoBehaviour
{
    [SerializeField] GameObject turnOffIcon;
    List<GameObject> musicList = new List<GameObject>();

    public void OnClickTurnOffMusic()
    {
        turnOffIcon.SetActive(true);
        for (int i = 0; i < musicList.Count; i++)
        {
            musicList[i].SetActive(false);
        }
    }
    public void OnClickPlayMusic()
    {
        turnOffIcon.SetActive(false);
        for (int i = 0; i < musicList.Count; i++)
        {
            musicList[i].SetActive(true);
        }
    }
    public void FindMusicAudio()
    {
        foreach (GameObject _sound in GameObject.FindGameObjectsWithTag("Music"))
        {
            musicList.Add(_sound);
            Debug.Log(_sound);
        }
    }
    private void Start()
    {
        FindMusicAudio();
    }
}
