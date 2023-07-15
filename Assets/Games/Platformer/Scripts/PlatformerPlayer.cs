using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    private StateMachine _SM; // переменная StateMachine
    private WalkState _walkState; // переменная состояния
    private IdleState _idleState;
    private JumpState _jumpState;
    private float _horizontalMove;

    [HideInInspector] public Animator _anim;
    private Rigidbody2D _rb;
    private BoxCollider2D _box;
    private Vector2 _leftPoint;
    private Vector2 _rightPoint;
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

        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();

    }
    void Start()
    {
        

        _SM.Initialize(_idleState); // при старте вызываем состояние покоя

        Calculations();
    }

    private void Calculations() // высчитываю положения 2-ух raycasts
    {
        Vector2 BoxPosition = _box.transform.position;
        Vector2 _boxSize = _box.size;
        Vector2 _boxCenter = _box.offset + BoxPosition;
        _leftPoint = new Vector2(_boxCenter.x - _boxSize.x / 2, _boxCenter.y - _boxSize.y / 2 + 0.0001f);
        _rightPoint = new Vector2(_boxCenter.x + _boxSize.x / 2, _boxCenter.y - _boxSize.y / 2 +0.0001f);
    }
    public void Jump()
    {
        _rb.AddForce(Vector2.up * jumpForse, ForceMode2D.Impulse);
        _isGrounded = false;
    }
    
    public void HorizontalMove()
    {
        Vector2 deltaX = _input.Player.Move.ReadValue<Vector2>() * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX.x, _rb.velocity.y);
        _rb.velocity = movement;

    }

    void FixedUpdate()
    {
        //HorizontalMove();
        //_SM.CurrentState.FixedUpdate();
    }
    void Update()
    {
        Vector2 deltaX = _input.Player.Move.ReadValue<Vector2>();
        _horizontalMove = deltaX.x;
        HorizontalMove();
        
        Calculations();
        Debug.Log(_SM.CurrentState);
        

        RaycastHit2D hit = Physics2D.Raycast(_leftPoint, Vector2.down, 0.01f);
        RaycastHit2D hit2 = Physics2D.Raycast(_rightPoint, Vector2.down, 0.01f);
        Debug.DrawRay(_leftPoint, Vector2.down, Color.red, 0.02f);
        Debug.DrawRay(_rightPoint, Vector2.down, Color.red, 0.1f);

        if (hit == true || hit2 ==true)
        {
            //Debug.Log(hit.transform.gameObject.name);
            //Debug.Log(hit.transform.position);
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        //_SM.CurrentState.FixedUpdate();
        CheckState();
    }

    private void CheckState()
    {
        if (_isGrounded == true && _horizontalMove != 0)
        {
            _SM.ChangeState(_walkState);
        }

        if (_isGrounded == true && _input.Player.Jump.triggered)//Input.GetKeyDown(KeyCode.Space)
        {
            _SM.ChangeState(_jumpState);
        }

        if (_isGrounded == true && _horizontalMove == 0)
        {
            _SM.ChangeState(_idleState);
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
