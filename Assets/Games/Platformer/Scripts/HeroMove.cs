using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroMove : MonoBehaviour
{
    private PlatformerInput _input;
    private Rigidbody2D _rb;

    public float speed;
    [SerializeField] private float jumpForce;
    //private bool isJumping = false;
    //private bool isGrounded = false;
    public BoxCollider2D groundCheck;
    //private Vector3 velocity;

    void Awake()
    {
        _input = new PlatformerInput();

        _input.Player.Jump.performed += ContextMenu => Jump();
    }
    void OnEnable()
    {
        _input.Enable();
    }

    void OnDisable()
    {
        _input.Disable();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 moveDirection = _input.Player.Move.ReadValue<Vector2>();
        Move(moveDirection);
    }

    public void Jump()
    {

             _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);


    }

    public void Move(Vector2 moveDirection)
    {
        transform.Translate(moveDirection*speed);
    }
}
