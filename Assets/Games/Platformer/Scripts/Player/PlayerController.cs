using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace GamePlatformer
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerModel Model;
        [HideInInspector] public PlayerView View;

        #region StateMachine

        [HideInInspector] public StateMachine SM;
        [HideInInspector] public WalkState walkState;
        [HideInInspector] public IdleState idleState;
        [HideInInspector] public JumpState jumpState;
        [HideInInspector] public FallState fallState;
        [HideInInspector] public DeathState deathState;
        [HideInInspector] public TakeDamageState takeDamageState;

        #endregion

        public LayerMask _trapMask;
        public LayerMask groundLayer;

        [HideInInspector] public Rigidbody2D _rb;

        [HideInInspector] public PlatformerInput _input;




        #region Movement

        [HideInInspector] public Vector2 _inputMove;
        [HideInInspector] public Vector2 _targetSpeed;

        public float _maxIdleSpeed;

        public BoxCollider2D _groundChecker;
        public bool _isGrounded = false;

        [HideInInspector] public PlayerSpawner PlayerSpawner;
        [HideInInspector] public MovingCamera movingCamera;

        #endregion

        void Awake()
        {
            Model = GetComponent<PlayerModel>();
            View = GetComponent<PlayerView>();

            _input = new PlatformerInput();
            _input.Player.Jump.performed += context => Jump();

            SM = new StateMachine(); // подключаем состояния
            idleState = new IdleState(this);
            walkState = new WalkState(this);
            jumpState = new JumpState(this);
            fallState = new FallState(this);
            deathState = new DeathState(this);
            takeDamageState = new TakeDamageState(this);

            _rb = GetComponent<Rigidbody2D>();


        }

        void Start()
        {
            PlayerSpawner = GameObject.FindObjectOfType<PlayerSpawner>();
            movingCamera = GameObject.FindObjectOfType<MovingCamera>();
            SM.Initialize(idleState); // при старте вызываем состояние покоя
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Jump()
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector2.up * Model.jumpForse, ForceMode2D.Impulse);
                _isGrounded = !_isGrounded;
            }
        }

        public void Flip()
        {
            View._isFacingRight = !View._isFacingRight;
            transform.Rotate(.0f, 180f, .0f);
        }

        public void GroundCheck()
        {
            _isGrounded = Physics2D.BoxCast(_groundChecker.bounds.center, _groundChecker.bounds.size,
                0f, Vector2.down, .01f, groundLayer);
        }

        void FixedUpdate()
        {
            _inputMove = _input.Player.Move.ReadValue<Vector2>();
            GroundCheck();
            SM.CurrentState.FixedUpdate();
        }

        //public void TakeDamage()
        //{
        //    if (Model._isVulnerability)
        //    {
        //        SM.ChangeState(takeDamageState);
        //         Model._isVulnerability = !Model._isVulnerability;
        //    }
        //}

        public void HorizontalMove()
        {

            if (Time.time > View._nextStep && SM.CurrentState == walkState)
            {
                View._nextStep = Time.time + View._stepRate;
                View._soundStep.pitch = Random.Range(0.8f, 1.2f);
                View._soundStep.Play();
            }

            _targetSpeed = _inputMove * Model.speed; // скорость основанная на входных данных
            float speedDifX = _targetSpeed.x - _rb.velocity.x; // разница между текущей скоростью и скоростью основанной на входных данных
            float accelRate = (Mathf.Abs(_targetSpeed.x) > 0.1f) ? Model.acceleration : Model.decceleration; // ускорение в зависимости нажата ли кнопка
            float movement = Mathf.Pow(Mathf.Abs(speedDifX) * accelRate, Model.velPower) * Mathf.Sign(speedDifX);
            _rb.AddForce(movement * Vector2.right);

            if (_targetSpeed.x ==0)
            {
                float amount = Mathf.Min(Mathf.Abs(_rb.velocity.x), Mathf.Abs(Model.frictionAmount));
                amount *= Mathf.Sign(_rb.velocity.x);
                _rb.AddForce(Vector2.right*-amount,ForceMode2D.Impulse);
            }

            CheckMaxSpeed();
            CheckMovementDirection();

        }

        private void CheckMaxSpeed()
        {
            if (Mathf.Abs(_rb.velocity.x) > _maxIdleSpeed) //установка максимальной скорости
            {
                if (_rb.velocity.x > _maxIdleSpeed)
                {
                    _rb.velocity = new Vector2(_maxIdleSpeed, _rb.velocity.y);
                }

                if (_rb.velocity.x < -_maxIdleSpeed)
                {
                    _rb.velocity = new Vector2(-_maxIdleSpeed, _rb.velocity.y);
                }
            }
        }

        private void CheckMovementDirection()
        {
            if (View._isFacingRight && _inputMove.x < 0)
            {
                Flip();
            }
            else if (View._isFacingRight == false && _inputMove.x > 0)
            {
                Flip();
            }
        }

        void OnTriggerEnter2D(Collider2D collision)
        {

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (Model._isVulnerability == true)
            {
                if (collision.gameObject.tag == "Trap")
                {
                    SM.ChangeState(takeDamageState);
                }

                if (collision.gameObject.tag == "Enemy")
                {
                    SM.ChangeState(takeDamageState);
                }
            }
        }

        public void DestroyHero()
        {
            gameObject.SetActive(false);
            RespawnHero();
        }

        public void RespawnHero()
        {
            PlayerSpawner.CreatePlayer();
            movingCamera.FindPlayer();
        }

        #region CheckStates

        public void CheckStateDeath()
        {
            if (Model.lives == 0)
            {
                SM.ChangeState(deathState);
            }
            else
            {
                Model._isVulnerability = true;
                SM.CurrentState.CheckState();
            }
        }
        public void CheckStateIdle()
        {
            if (_isGrounded && _rb.velocity.x == 0)
            {
                SM.ChangeState(idleState);
            }
        }

        public void CheckStateWalk()
        {
            if (_isGrounded && _inputMove.x != 0)
            {
                SM.ChangeState(walkState);
            }
        }

        public void CheckStateJump()
        {
            if (!_isGrounded && _rb.velocity.y > 0.1f)
            {
                SM.ChangeState(jumpState);
            }
        }

        public void CheckStateFall()
        {
            if (!_isGrounded && _rb.velocity.y < 0.1f)
            {
                SM.ChangeState(fallState);
            }
        }

        #endregion
    }
}
