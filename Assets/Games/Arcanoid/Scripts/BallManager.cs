using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private PlayerMove _platform;
    private GameObject _ball;

    [SerializeField] public GameObject ballPrefab;
    private const float OffsetX = 0.4f; // чтоб по€вилс€ р€дом платформой

    public void Initialize()
    {
    _platform = GameObject.FindObjectOfType<PlayerMove>(); // ссылка на созданную платформу

        CreateStartBall();
    }

    public void CreateStartBall() // создание м€ча р€дом с платформой
    {
        _ball = Instantiate(ballPrefab, new Vector3(_platform.transform.position.x + OffsetX, _platform.transform.position.y), Quaternion.identity);
    }

    public void BallDestroy() 
    {
        Destroy(_ball); //уничтожение ранее созданного м€ча
        CalculationCenter.ResetDamage(); // сброс накопленного урона
        CreateStartBall(); // создать новый шарик
    }
}
