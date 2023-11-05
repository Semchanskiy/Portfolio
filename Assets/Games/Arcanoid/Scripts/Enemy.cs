using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameArcanoid
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text; // ��������� ���� ������
        private int _health; // ���� ��������

        private void Start()
        {
            _health = 100; // ���� ��������
            _text.text = "Health: " + _health; // ����� ������� �������� � �����
        }

        public void DealDamage(int _damage) // ����� ��������� �����
        {
            _health -= _damage; //�������� �������� 
            _text.text = "Health: " + _health; // ����� ������� �������� � �����
            if (_health <= 0) // ���������� ����� ���� �������� ������ ��� ����� 0
            {
                Destroy(gameObject);
            }
        }
    }
}
