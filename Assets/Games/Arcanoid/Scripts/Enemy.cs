using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameArcanoid
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _text; // объявляем поле текста
        private int _health; // поле здоровья

        private void Start()
        {
            _health = 100; // даем здоровье
            _text.text = "Health: " + _health; // пишем сколько здоровья у врага
        }

        public void DealDamage(int _damage) // метод получения урона
        {
            _health -= _damage; //вычитаем здоровье 
            _text.text = "Health: " + _health; // пишем сколько здоровья у врага
            if (_health <= 0) // уничтожаем врага если здоровье меньше или ранво 0
            {
                Destroy(gameObject);
            }
        }
    }
}
