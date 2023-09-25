using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _boxCollider2D;
    private SpriteRenderer _spriteRenderer;
    private PBall _ball;

    private Vector2 _rotateInput;
    private Camera _camera;
    private InputPlatforma _input;

    [Header("Move Settings")]
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _cooldown;
    [SerializeField] private float _power;

    private Vector2 _force;

    [SerializeField] private bool _isActive = true;
    [SerializeField] private float _minCollisions;
    private bool _timeCollision = false;
    private float _collisions;
    

    private void Awake()
    {
        _input = new InputPlatforma();
    }
    void Start()
    {
        _ball = FindAnyObjectByType<PBall>();
        _camera = Camera.main;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void TakeCollisionsCount(float _col)
    {
        _collisions = _col;
        CheckActive();
    }

    private void CheckActive()
    {
        if(!_isActive && _collisions>=_minCollisions && _timeCollision)
        {
            ActivetedPlatform();
        }
    }

    IEnumerator AddForce(Vector2 Force)
    {
        yield return new WaitForFixedUpdate();
        _ball.PlatformAddForce(Force);

    }
    IEnumerator EnablePlatform()
    {
        yield return new WaitForSeconds(_cooldown);
        _timeCollision = true;
        CheckActive();
    }

    private void ActivetedPlatform()
    {
        _boxCollider2D.enabled = true;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.b, _spriteRenderer.color.g, 1f);
        _isActive = !_isActive;
    }
    private void DisActivatedPlatform()
    {
        _isActive = !_isActive;
        _timeCollision = false;
        _boxCollider2D.enabled = false;
        _spriteRenderer.color = new Color(_spriteRenderer.color.r, _spriteRenderer.color.b, _spriteRenderer.color.g, 0.3f);
        StartCoroutine(EnablePlatform());
        _force = _ball.GetComponent<Rigidbody2D>().velocity * _power;
        StartCoroutine(AddForce(_force));
    }

    void Update()
    {
        _rotateInput = _input.Platforma.Rotate.ReadValue<Vector2>();

        RotateMove();
        PositionMove();
        PowerDif();
    }

    private void PowerDif()
    {
        _power = _power + _rotateInput.y * 0.5f*Time.deltaTime;
    }

    private void PositionMove()
    {
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _c = _mousePos-new Vector2(_rb.transform.position.x,_rb.transform.position.y);
        _rb.velocity = _c*_speedMove;

    }
    private void RotateMove() 
    { 
        if (_rotateInput.x !=0)
        {
        _rb.transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z - _rotateInput.x * _speedRotation) * Time.deltaTime);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Pball")
        {
            DisActivatedPlatform();
        }
        
    }
}
