using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CalculationCenter : MonoBehaviour
{
    private static Enemy _enemy; // ссылка на врага
    public static UnityEvent<int> CurrentDamage = new UnityEvent<int>(); // событие, вызывающиеся при изменении счета
    public static int _damage; // текущий накопленный урон

    void Start()
    {
        _damage = 0;
        _enemy = FindObjectOfType<Enemy>();
        
    }
    
    public static void AddDamage(int Damage) // метод добавления урона
    {
        _damage += Damage;
        CurrentDamage.Invoke(_damage);
    }

    public static void ResetDamage() // метод нанесения урона врагу и обновления урона
    {
        if(_enemy != null)
        {
        _enemy.DealDamage(_damage);
        }
        _damage = 0;
        CurrentDamage.Invoke(_damage);
    }


}
