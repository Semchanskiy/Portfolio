using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Probn : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.TryGetComponent(out BallCreator box))
        //{
        //    Debug.Log(box.name);
        //}
    }
}
