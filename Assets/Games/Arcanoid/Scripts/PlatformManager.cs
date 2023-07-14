using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] public GameObject PlatformPrefab;
    public void Initialize() 
    {
        Instantiate(PlatformPrefab, new Vector3(-5.1f, -1f), Quaternion.identity); // создание платформы на нужной позиции
    }
}
