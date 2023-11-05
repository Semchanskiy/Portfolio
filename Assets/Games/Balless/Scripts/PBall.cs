using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBalless
{
    public class PBall : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private Platforma _platforma;
        private float _collisions = 0;
        private float maxModSpeed = 0;

        void Start()
        {
            _platforma = FindAnyObjectByType<Platforma>();
            _rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            float modSpeed = Mathf.Abs(_rb.velocity.x) + Mathf.Abs(_rb.velocity.y);

            if (modSpeed >= maxModSpeed)
            {
                maxModSpeed = modSpeed;

            }
        }

        public void PlatformAddForce(Vector2 Force)
        {
            _rb.velocity = Force;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Platforma")
            {
                _collisions = 0;
                _platforma.TakeCollisionsCount(_collisions);
            }

            else
            {
                _collisions++;
                _platforma.TakeCollisionsCount(_collisions);
            }
        }
    }
}
