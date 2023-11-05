using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameArcanoid
{
    public class Score : MonoBehaviour
    {

        private int _AllDamage;
        [SerializeField] private TextMeshProUGUI _text; // поле для текста

        void Start()
        {
            CalculationCenter.CurrentDamage.AddListener(AddDamage); // подписываемся на событие
            _AllDamage = 0;
            _text.text = "Damage: ";
        }

        public void AddDamage(int x) // метод написания текущего накопленного урона
        {
            _AllDamage = x;
            _text.text = "Damage: " + _AllDamage;
        }



    }
}

