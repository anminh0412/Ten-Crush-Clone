using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGetClickEvent : MonoBehaviour
{
    AudioSource click_sound;
    AudioSource click_lock_sound;
    int _currentLevelPosition;
    GetCurrentLevel getCurrentLevel;
    private void Start()
    {
        _currentLevelPosition = GetComponent<LevelStatus>()._level - 1;
        getCurrentLevel = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GetCurrentLevel>();
    }
    void OnEnable()
    {
        GameObject go1 = GameObject.Find("click_sound");
        GameObject go2 = GameObject.Find("click_lock_level_sound");
        if(go1 != null ) click_sound = go1.GetComponent<AudioSource>();
        if(go2 != null ) click_lock_sound = go2.GetComponent<AudioSource>();
    }
    public void OnClickLevelSound()
    {
        if (click_sound == null) return;
        click_sound.Play();
    }
    public void OnClickLockLevelSound()
    {
        if (click_lock_sound == null) return;
        click_lock_sound.Play();
    }
    public void OnClickChangeCurrentLevel()
    {
        getCurrentLevel.ChangeCurrentLevel(_currentLevelPosition);
    }
}
