using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBalless
{
    public class PBallCamera : MonoBehaviour
    {
        [SerializeField] private PBall _ball;
        private Rigidbody2D _rb;
        [SerializeField] private float _speed;
        private Vector2 _napr;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            transform.position = new Vector3(_ball.transform.position.x, _ball.transform.position.y, -10);
        }

        // Update is called once per frame
        void Update()
        {
            _rb.velocity = new Vector2(_ball.transform.position.x - transform.position.x,
                _ball.transform.position.y - transform.position.y) * _speed;
        }
    }
}
