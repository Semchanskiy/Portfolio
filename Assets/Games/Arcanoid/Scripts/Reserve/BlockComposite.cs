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
        Debug.Log(position); // ��� ������
        //Instantiate(test, position, Quaternion.identity);
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(position, 0.002f); //LayerMask.NameToLayer("Block") //� ������ ������������ ���������� � ������������ �������



        if (collider2Ds.Length > 0) // ���� ���������� � ������� ����
        {
            foreach (var item in collider2Ds) // ��������� ����������
            {
                if (item.TryGetComponent(out SmallBlock block)) // ���� ��� ����
                {
                    Debug.Log(collider2Ds.Length); // ����������� ����������� � ������� ��� ������
                    //Debug.Log(block.name);
                    block.Punch(); //��������� ����� �����
                    break; //���������� ���� ��� ��� �� ��������� ���������� ��������� ������ �� ���� �������
                }
            }
        }
    }
}
}
