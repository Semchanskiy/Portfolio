using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class BlockComposite : MonoBehaviour
{
    //[SerializeField] private GameObject test;
    public void ApplyDamage(Vector2 position)
    {
        Debug.Log(position); // для дебага
        //Instantiate(test, position, Quaternion.identity);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(position, 0.002f); //LayerMask.NameToLayer("Block") //в массив записываются коллайдеры в определенном радиусе



        if (collider2Ds.Length > 0) // если коллайдеры в радиусе есть
        {
            foreach (var item in collider2Ds) // перебирем коллайдеры
            {
                if (item.TryGetComponent(out SmallBlock block)) // если это блок
                {
                    Debug.Log(collider2Ds.Length); // колличество коллайдеров в массиве для дебага
                    //Debug.Log(block.name);
                    block.Punch(); //нанесение урона блоку
                    break; //прекращаем цикл так как не требуется уничтожать несколько блоков за одно касание
                }
            }
        }
    }
}
}
