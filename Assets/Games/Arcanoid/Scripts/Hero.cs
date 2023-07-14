using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    private int _lives; // ���-�� ��������
    [SerializeField] private TextMeshPro _text; // ��������� ���� ������
    void Start()
    {
        _lives = 100; // ���� ��������
        _text.text = "Health: " + _lives;  // ����� ������� �������� � �����
    }

    public void GetDamage(int _damage) // ����� ��������� �����
    {
        _lives = _lives - _damage;
        _text.text = "Health: " + _lives;  // ����� ������� �������� � �����
        if (_lives <= 0) // ���� �������� <=0 ��������� ����
        {
            GameOver();
        }
        
    }
    private void GameOver()
    {

        gameObject.SetActive(false);
    }
}
