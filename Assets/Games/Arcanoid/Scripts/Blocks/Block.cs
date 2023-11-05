using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public abstract class Block : MonoBehaviour
    {
        //[SerializeField] private GameObject test;
        protected int _lives; // ���-�� ������ ��� ����������� �����
        protected int _score; // ���� ��� ���������� ���� � ������ �������� �����
        protected Animator anim;
        protected BoxCollider2D box2d;
        protected BallManager _ballManager;
        protected Score _scoreManager;

        void Start()
        {
            _scoreManager = FindAnyObjectByType<Score>();
            _ballManager = FindAnyObjectByType<BallManager>();
            anim = GetComponent<Animator>();
            box2d = GetComponent<BoxCollider2D>();
            Specifications();
        }

        protected virtual void Specifications()
        {
            _lives = 1;
        }

        public virtual void Punch() // ���������� ����
        {
            _lives--; // ���������� ����� � �����
            if (_lives == 0)
            {
                if (anim != null) // ���� ���� ��������
                {
                    anim.SetBool("Destroy", true); // ���� ������������
                    CalculationCenter.AddDamage(_score); // �������� ���� � ������ ��������


                }
                else
                {
                    CalculationCenter.AddDamage(_score);
                    gameObject.SetActive(false);
                }
            }
        }

        public virtual void Destroys() // ����� ����������� �����
        {
            gameObject.SetActive(false);
        }

    }
}
