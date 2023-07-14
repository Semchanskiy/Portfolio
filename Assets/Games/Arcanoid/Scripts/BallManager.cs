using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    private PlayerMove _platform;
    private GameObject _ball;

    [SerializeField] public GameObject ballPrefab;
    private const float OffsetX = 0.4f; // ���� �������� ����� ����������

    public void Initialize()
    {
    _platform = GameObject.FindObjectOfType<PlayerMove>(); // ������ �� ��������� ���������

        CreateStartBall();
    }

    public void CreateStartBall() // �������� ���� ����� � ����������
    {
        _ball = Instantiate(ballPrefab, new Vector3(_platform.transform.position.x + OffsetX, _platform.transform.position.y), Quaternion.identity);
    }

    public void BallDestroy() 
    {
        Destroy(_ball); //����������� ����� ���������� ����
        CalculationCenter.ResetDamage(); // ����� ������������ �����
        CreateStartBall(); // ������� ����� �����
    }
}
