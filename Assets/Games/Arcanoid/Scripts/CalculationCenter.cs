using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculationCenter : MonoBehaviour
{
    private static Enemy _enemy; // ������ �� �����
    public static UnityEvent<int> CurrentDamage = new UnityEvent<int>(); // �������, ������������ ��� ��������� �����
    public static int _damage; // ������� ����������� ����

    void Start()
    {
        _damage = 0;
        _enemy = FindObjectOfType<Enemy>();
        
    }
    
    public static void AddDamage(int Damage) // ����� ���������� �����
    {
        _damage += Damage;
        CurrentDamage.Invoke(_damage);
    }

    public static void ResetDamage() // ����� ��������� ����� ����� � ���������� �����
    {
        if(_enemy != null)
        {
        _enemy.DealDamage(_damage);
        }
        _damage = 0;
        CurrentDamage.Invoke(_damage);
    }


}
