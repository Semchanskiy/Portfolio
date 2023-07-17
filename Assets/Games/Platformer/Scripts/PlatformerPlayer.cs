using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    private StateMachine _SM; // переменная StateMachine
    private WalkState _walkState; // переменная состояния
    private IdleState _idleState; // переменная состояния
    private JumpState _jumpState; // переменная состояния
    private FallState _fallState; // переменная состояния
    private Vector2 _inputMove;
    private Vector2 _targetSpeed;
    private float _horizontalMove;
    private float _dirX;


    [HideInInspector] public Animator _anim;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _sprite;

    [SerializeField] private BoxCollider2D _groundChecker;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool _isGrounded = false;

    [SerializeField] private PlatformerInput _input;

    

    public float speed;
    public float maxSpeed;
    public float jumpForse;
    [SerializeField] private float _acceleration;
    [SerializeField] private float _decceleration;
    [SerializeField] private float velPower;

    void Awake()
    {
        _input = new PlatformerInput();
        _input.Player.Jump.performed += context => Jump();

        _SM = new StateMachine();
        _idleState = new IdleState(this);
        _walkState = new WalkState(this);
        _jumpState = new JumpState(this);
        _fallState = new FallState(this);

        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        _SM.Initialize(_idleState); // при старте вызываем состояние покоя
    }
    public void Jump()
    {
        if (_isGrounded) 
        { 
        _rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        }
    }
    public void HorizontalMove()
    {
        _inputMove = _input.Player.Move.ReadValue<Vector2>();
        //if (_inputMove.x !=0) 
        //{
        _targetSpeed = _inputMove * speed;  // скорость основанная на входных данных
        float speedDifX = _targetSpeed.x - _rb.velocity.x; // разница между текущей скоростью и скоростью основанной на входных данных
        float accelRate = (Mathf.Abs(_targetSpeed.x) > 0.01f) ? _acceleration : _decceleration; // ускорение в зависимости нажата ли кнопка
        float movement = Mathf.Pow(Mathf.Abs(speedDifX) * accelRate, velPower) * Mathf.Sign(speedDifX); // чем 

        _rb.AddForce(movement * Vector2.right);
        //}
    }

    //private void Flip()
    //{
       // _dirX = _
       // _sprite.flipY = true;
    //}

    void FixedUpdate()
    {
        GroundCheck();

        HorizontalMove();
        CheckState();
        Debug.Log(_SM.CurrentState);
        

    }

    private void GroundCheck()
    {
        _isGrounded = Physics2D.BoxCast(_groundChecker.bounds.center,_groundChecker.bounds.size, 0f, Vector2.down, .01f, groundLayer);
        
    }

    void Update()
    {
        
    }

    private void CheckState()
    {
        if (_isGrounded == true && _rb.velocity.x!=0)
        {
            _SM.ChangeState(_walkState);
        }

        if (_isGrounded == false && _rb.velocity.y>0)  
        {
            _SM.ChangeState(_jumpState);
        }

        if (_isGrounded == true && _rb.velocity.x == 0)
        {
            _SM.ChangeState(_idleState);
        }

        if (_isGrounded == false && _rb.velocity.y < 0)
        {
            _SM.ChangeState(_fallState);
        }

    }

    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
}
