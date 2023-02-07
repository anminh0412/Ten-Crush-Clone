using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource clickSound;
    [SerializeField] AudioSource bgSound;
    public void OnClickPlaySound()
    {
        //if (clickSound == null) return;
        clickSound.Play();
    }
}
