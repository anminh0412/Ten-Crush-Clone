using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGetLevel : MonoBehaviour
{
    public GameObject prefab;

    void Spawn()
    {
        if (!GameObject.FindGameObjectWithTag("GrabLevelInfo"))
        {
            GameObject go = Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            DontDestroyOnLoad(go);
        }
        else return;
    }
    private void Start()
    {
        Spawn();
    }
}
