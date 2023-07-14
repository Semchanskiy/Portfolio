using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : Block
{
    protected override void Specifications()
    {
        _lives = -1; // ����� ������� �� �����������
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallMove ball)) // ���� ������������ � �������
        {
            _ballManager.GetComponent<BallManager>().BallDestroy(); // ���������� ���� �����
        }
    }
}
