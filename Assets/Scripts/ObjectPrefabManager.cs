using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectPrefabManager : MonoBehaviour
{
    public int gOValue;
    [SerializeField] TextMeshPro text;


    private void Start()
    {
        Debug.Log(gOValue);
        text.SetText(gOValue.ToString());
    }
}
