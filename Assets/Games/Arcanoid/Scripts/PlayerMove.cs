using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class PlayerMove : MonoBehaviour
    {

        private Rigidbody2D _rigidbody2D;

        private float _speed = 4f; // скорость движения платформы
        private const float MaxBorderPosition = 1.25f;
        private const float MinBorderPosition = -3.25f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            float positionY = _rigidbody2D.position.y + Input.GetAxisRaw("Vertical") * _speed * Time.fixedDeltaTime;
            positionY = Mathf.Clamp(positionY, MinBorderPosition, MaxBorderPosition);
            _rigidbody2D.MovePosition(new Vector2(_rigidbody2D.position.x,
                positionY)); // перемещает платформу в назначенную точку

        }

    }
}
