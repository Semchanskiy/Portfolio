using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    #region StateMachine
    private StateMachine _SM; // переменная StateMachine
    private WalkState _walkState; // переменная состояния
    private IdleState _idleState; 
    private JumpState _jumpState; 
    private FallState _fallState; 
    #endregion

    [SerializeField] private LayerMask _trapMask;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D _rb;
    [HideInInspector] public Animator _anim;
    [SerializeField] private PlatformerInput _input;

    [SerializeField] private AudioSource _soundJump;
    [SerializeField] private AudioSource _soundStep;
    private float _nextStep = 0.0f;
    [SerializeField] private float _stepRate;

    #region Movement
    private Vector2 _inputMove;
    private Vector2 _targetSpeed;
    public float _maxIdleSpeed;
    private bool _isFacingRight = true;
    public float speed;
    public float jumpForse;
    public int _lives;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _decceleration;
    [SerializeField] private float velPower; // величина прилагаемой силы

    [SerializeField] private BoxCollider2D _groundChecker;
    [SerializeField] private bool _isGrounded = false;
    private SpawnManager _spawnManager;
    private MovingCamera _movingCamera;
    #endregion

    void Awake()
    {
        _input = new PlatformerInput();
        _input.Player.Jump.performed += context => Jump();

        _SM = new StateMachine(); // подключаем состояния
        _idleState = new IdleState(this);
        _walkState = new WalkState(this);
        _jumpState = new JumpState(this);
        _fallState = new FallState(this);

        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();

    }

    void Start()
    {
        _spawnManager = GameObject.FindAnyObjectByType<SpawnManager>();
        _movingCamera = GameObject.FindAnyObjectByType<MovingCamera>();
        _SM.Initialize(_idleState); // при старте вызываем состояние покоя

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    public void Jump()
    {
        if (_isGrounded) 
        { 
        _rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        _soundJump.Play();
        }
    }

    public void HorizontalMove()
    {
        _inputMove = _input.Player.Move.ReadValue<Vector2>();

        if (Time.time > _nextStep && _SM.CurrentState == _walkState)
        {
            _nextStep = Time.time + _stepRate;
            _soundStep.pitch = Random.Range(0.8f, 1.2f);            
            _soundStep.Play();
        }

        _targetSpeed = _inputMove * speed;  // скорость основанная на входных данных
        float speedDifX = _targetSpeed.x - _rb.velocity.x; // разница между текущей скоростью и скоростью основанной на входных данных
        float accelRate = (Mathf.Abs(_targetSpeed.x) > 0.01f) ? _acceleration : _decceleration; // ускорение в зависимости нажата ли кнопка
        float movement = Mathf.Pow(Mathf.Abs(speedDifX) * accelRate, velPower) * Mathf.Sign(speedDifX);
        _rb.AddForce(movement * Vector2.right);

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
        if(_isFacingRight && _inputMove.x < 0)
        {
            Flip();
        }
        else if (!_isFacingRight && _inputMove.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(.0f, 180f, .0f);
    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.BoxCast(_groundChecker.bounds.center,_groundChecker.bounds.size, 0f, Vector2.down, .01f, groundLayer);
    }

    void FixedUpdate()
    {
        HorizontalMove();
        GroundCheck();
        CheckState();
        Debug.Log(_SM.CurrentState);
    }

    private void CheckState()
    {

        if (_isGrounded == true && Mathf.Abs(_rb.velocity.x) > 0.1f)
        {
            _SM.ChangeState(_walkState);
            return;
        }

        if (_isGrounded == false && _rb.velocity.y>0)  
        {
            _SM.ChangeState(_jumpState);
            return;
        }

        if (_isGrounded == true && Mathf.Abs(_rb.velocity.x) < 0.1f)
        {
            _SM.ChangeState(_idleState);
            return;
        }

        if (_isGrounded == false && _rb.velocity.y < 0)
        {
            _SM.ChangeState(_fallState);
            return;
        }

        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "Trap")
        {
            Destroy();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
        _spawnManager.CreatePlayer();
        _movingCamera.FindPlayer();
    }
}
