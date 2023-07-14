using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : Block
{
    protected override void Specifications()
    {
        _lives = -1; // чтобы никогда не уничтожался
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BallMove ball)) // если сталкивается с шариком
        {
            _ballManager.GetComponent<BallManager>().BallDestroy(); // уничтожить этот шарик
        }
    }
}
