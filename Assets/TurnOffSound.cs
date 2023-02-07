using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSound : MonoBehaviour
{
    [SerializeField] GameObject turnOffIcon;
    List<GameObject> soundList = new List<GameObject>();

    public void OnClickTurnOffSound()
    {
        turnOffIcon.SetActive(true);
        for (int i = 0; i < soundList.Count; i++)
        {
            soundList[i].SetActive(false);
        }
    }
    public void OnClickPlaySound()
    {
        turnOffIcon.SetActive(false);
        for (int i = 0; i < soundList.Count; i++)
        {
            soundList[i].SetActive(true);
        }
    }
    public void FindSoundAudio()
    {
        foreach (GameObject _sound in GameObject.FindGameObjectsWithTag("Sound"))
        {
            soundList.Add(_sound);
            Debug.Log(_sound);
        }
    }
    private void Start()
    {
        FindSoundAudio();
    }
}
