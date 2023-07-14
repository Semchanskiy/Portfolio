using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerMove _platform; // игрок - платформа

    private bool _isActiv;

    //private float Speed = 1f;
    private float _vertForce = 0;
    private float _horizForce = 3; 
    private float _platformCenterPosition; // переменна€ центра пталформы
    private float _ballPositionY; // позици€ м€ча по Y


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _platform = GameObject.FindAnyObjectByType<PlayerMove>();
    }

    private void Update()
    {
        if (!_isActiv) // если м€ч не активен
        {
            if(Math.Abs(_platform.transform.position.y - transform.position.y) >= 1.2f) // провер€ет разницу по оси Y между платформой и м€чом
            {
                //transform.position = new Vector2(transform.position.x, _platform.transform.position.y - transform.position.y); 
                if (_platform.transform.position.y - transform.position.y <= -1.2f) // ставит его возле верхнего кра€ платформы
                {
               transform.position = new Vector2(transform.position.x,_platform.transform.position.y + 1.2f);
               }
               if (_platform.transform.position.y - transform.position.y >= 1.2f)   // ставит его возле нижнегоы кра€ платформы
                {
                   transform.position = new Vector2(transform.position.x, _platform.transform.position.y - 1.2f);
               }
            }


            if (Input.GetKeyDown(KeyCode.Space))  // нажата клавиша Space
           {
               BallActivete(); //вызвать метод активации м€ча
           }

        }
    }

    private void BallActivete() // метод активации м€ча
    {
        _isActiv = true; // переводим в активное состо€ние
        CalculationsMove(); // проводим расчеты отклонени€ от платформы
        Move(_horizForce,_vertForce); // при первом запуске м€ча кидаем его влево
    }
    private void CalculationsMove() // проводим расчеты отклонени€ от платформы
    {
        _ballPositionY = transform.position.y; // позици€ м€ча по Y
        _platformCenterPosition = _platform.gameObject.GetComponent<Transform>().position.y; // центр платформы
        float difference = (_ballPositionY - _platformCenterPosition);//разница между центром платформы и центром м€ча
        if (Math.Abs(difference) > 1.5f) // резулируем максимальное отклонение отскока м€ча от платформы
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
        _vertForce = difference * 2; // присваиваем значение на которое отклонитьс€ м€ч отскочив от платформы
    }
    private void Move(float x,float y) // даем направление м€чу 
    {
        _rb.velocity = new Vector2(x, y);
    }
    private void OnCollisionEnter2D(Collision2D collision) // если м€ч сталкнетс€ с чем либо
    {
        _ballPositionY = transform.position.y; //записываетс€ положение м€ча при любом касании

        if (collision.gameObject.TryGetComponent(out PlayerMove player)) // при соприкосновении с платформой
        {
            CalculationsMove();
            Move(_horizForce, _vertForce); // даем направление м€чу
        }

         if (collision.gameObject.TryGetComponent(out Block block)) // при соприкосновении с блоком
        {
            block.Punch(); // вызываем метод удара у этого блока
        }

    }
}
  