using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameArcanoid
{
    public class LostZone : MonoBehaviour
    {
        public BallManager _ballManager;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out BallMove ball)) // если сталкивается с шариком
            {
                _ballManager.BallDestroy();
            }
        }
    }
}
