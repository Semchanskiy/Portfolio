using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerMove _platform; // ����� - ���������

    private bool _isActiv;

    //private float Speed = 1f;
    private float _vertForce = 0;
    private float _horizForce = 3; 
    private float _platformCenterPosition; // ���������� ������ ���������
    private float _ballPositionY; // ������� ���� �� Y


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _platform = GameObject.FindAnyObjectByType<PlayerMove>();
    }

    private void Update()
    {
        if (!_isActiv) // ���� ��� �� �������
        {
            if(Math.Abs(_platform.transform.position.y - transform.position.y) >= 1.2f) // ��������� ������� �� ��� Y ����� ���������� � �����
            {
                //transform.position = new Vector2(transform.position.x, _platform.transform.position.y - transform.position.y); 
                if (_platform.transform.position.y - transform.position.y <= -1.2f) // ������ ��� ����� �������� ���� ���������
                {
               transform.position = new Vector2(transform.position.x,_platform.transform.position.y + 1.2f);
               }
               if (_platform.transform.position.y - transform.position.y >= 1.2f)   // ������ ��� ����� �������� ���� ���������
                {
                   transform.position = new Vector2(transform.position.x, _platform.transform.position.y - 1.2f);
               }
            }


            if (Input.GetKeyDown(KeyCode.Space))  // ������ ������� Space
           {
               BallActivete(); //������� ����� ��������� ����
           }

        }
    }

    private void BallActivete() // ����� ��������� ����
    {
        _isActiv = true; // ��������� � �������� ���������
        CalculationsMove(); // �������� ������� ���������� �� ���������
        Move(_horizForce,_vertForce); // ��� ������ ������� ���� ������ ��� �����
    }
    private void CalculationsMove() // �������� ������� ���������� �� ���������
    {
        _ballPositionY = transform.position.y; // ������� ���� �� Y
        _platformCenterPosition = _platform.gameObject.GetComponent<Transform>().position.y; // ����� ���������
        float difference = (_ballPositionY - _platformCenterPosition);//������� ����� ������� ��������� � ������� ����
        if (Math.Abs(difference) > 1.5f) // ���������� ������������ ���������� ������� ���� �� ���������
        {
            if (difference > 0)
            {
                difference = 1.5f;
            }
            else
            {
                difference = -1.5f;
            }
        }
        _vertForce = difference * 2; // ����������� �������� �� ������� ����������� ��� �������� �� ���������
    }
    private void Move(float x,float y) // ���� ����������� ���� 
    {
        _rb.velocity = new Vector2(x, y);
    }
    private void OnCollisionEnter2D(Collision2D collision) // ���� ��� ���������� � ��� ����
    {
        _ballPositionY = transform.position.y; //������������ ��������� ���� ��� ����� �������

        if (collision.gameObject.TryGetComponent(out PlayerMove player)) // ��� ��������������� � ����������
        {
            CalculationsMove();
            Move(_horizForce, _vertForce); // ���� ����������� ����
        }

         if (collision.gameObject.TryGetComponent(out Block block)) // ��� ��������������� � ������
        {
            block.Punch(); // �������� ����� ����� � ����� �����
        }

    }
}
  