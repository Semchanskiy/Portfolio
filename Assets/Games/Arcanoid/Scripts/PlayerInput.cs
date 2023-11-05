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
                Input.GetAxisRaw("Horizontal")); //взовем событие и передадим ему полученную переменную горизонтал
        }

        private void GetTouchInput()
        {
            if (Input.touchCount > 0) //если есть касание
            {
                Touch touch = Input.GetTouch(0); // считывается касание

                switch (touch.phase)
                {
                    //case TouchPhase.Began: // палец коснулся экрана
                    //    break;
                    case TouchPhase.Moved: // палец движется по экрану
                        _direction = touch.position.x > _startPosition.x ? 1f : -1f; // присваиваем значение направлению
                        break;
                    //case TouchPhase.Stationary: // плец касается экрана, но не двигается
                    //    break;
                    //case TouchPhase.Ended: // палец был убран с экрана
                    //    break;
                    //case TouchPhase.Canceled: // система отменила отслеживание касаний
                    //    break;
                    default:
                        _startPosition = touch.position;
                        _direction = 0f;
                        break;
                }

                OnMove?.Invoke(_direction); //вызывваем событие, передав направление движения
            }
        }
    }
}
