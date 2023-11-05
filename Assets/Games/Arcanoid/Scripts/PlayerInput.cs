using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class PlayerInput : MonoBehaviour
    {
        public static event Action<float> OnMove;

        private Vector2 _startPosition = Vector2.zero; //
        private float _direction = 0f;

        private void Update()
        {
            OnMove?.Invoke(
                Input.GetAxisRaw("Horizontal")); //������ ������� � ��������� ��� ���������� ���������� ����������
        }

        private void GetTouchInput()
        {
            if (Input.touchCount > 0) //���� ���� �������
            {
                Touch touch = Input.GetTouch(0); // ����������� �������

                switch (touch.phase)
                {
                    //case TouchPhase.Began: // ����� �������� ������
                    //    break;
                    case TouchPhase.Moved: // ����� �������� �� ������
                        _direction = touch.position.x > _startPosition.x ? 1f : -1f; // ����������� �������� �����������
                        break;
                    //case TouchPhase.Stationary: // ���� �������� ������, �� �� ���������
                    //    break;
                    //case TouchPhase.Ended: // ����� ��� ����� � ������
                    //    break;
                    //case TouchPhase.Canceled: // ������� �������� ������������ �������
                    //    break;
                    default:
                        _startPosition = touch.position;
                        _direction = 0f;
                        break;
                }

                OnMove?.Invoke(_direction); //��������� �������, ������� ����������� ��������
            }
        }
    }
}
