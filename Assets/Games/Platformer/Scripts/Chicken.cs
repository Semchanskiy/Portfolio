using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlatformer
{
    public class Chicken : MonoBehaviour
    {

        [SerializeField] private BoxCollider2D _groundChecker;
        [SerializeField] private float _speed;
        [SerializeField] private bool _isGrounded;
        [SerializeField] private LayerMask _groundLayer;
        private bool _isFacingRight = true;
        private Rigidbody2D _rb;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Flip()
        {
            _isFacingRight = !_isFacingRight;
            transform.Rotate(.0f, 180f, .0f);
        }

        void FixedUpdate()
        {
            GroundCheck();
            if (!_isGrounded)
            {
                Flip();
            }

            if (_isFacingRight)
            {
                _rb.velocity = new Vector2(_speed, 0);
            }
            else
            {
                _rb.velocity = new Vector2(-_speed, 0);
            }
        }

        private void GroundCheck()
        {
            _isGrounded = Physics2D.BoxCast(_groundChecker.bounds.center, _groundChecker.bounds.size, 0f, Vector2.down,
                .01f, _groundLayer);
        }

        void Update()
        {

        }
    }
}
