using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hero : MonoBehaviour
{
    private int _lives; // кол-во здоровья
    [SerializeField] private TextMeshPro _text; // объявляем поле текста
    void Start()
    {
        _lives = 100; // даем здоровье
        _text.text = "Health: " + _lives;  // пишем сколько здоровья у героя
    }

    public void GetDamage(int _damage) // метод получения урона
    {
        _lives = _lives - _damage;
        _text.text = "Health: " + _lives;  // пишем сколько здоровья у героя
        if (_lives <= 0) // если здоровье <=0 закончить игру
        {
            GameOver();
        }
        
    }
    private void GameOver()
    {

        gameObject.SetActive(false);
    }
}
