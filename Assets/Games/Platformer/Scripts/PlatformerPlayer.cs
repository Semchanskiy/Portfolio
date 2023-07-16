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
    private float _horizontalMove;


    [HideInInspector] public Animator _anim;
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;

    //[SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool _isGrounded = false;

    [SerializeField] private PlatformerInput _input;

    

    public float speed;
    public float jumpForse;

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
        Vector2 deltaX = _input.Player.Move.ReadValue<Vector2>() * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX.x, _rb.velocity.y);
        _rb.velocity = movement;
    }

    void FixedUpdate()
    {
        _isGrounded = Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f, Vector2.down ,.01f, groundLayer);
        Vector2 deltaX = _input.Player.Move.ReadValue<Vector2>();
        _horizontalMove = deltaX.x;
        HorizontalMove();
        CheckState();
        Debug.Log(_SM.CurrentState);
        

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
