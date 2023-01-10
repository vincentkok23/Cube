using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _speed;
    public float _jumpHeight;
    Rigidbody2D _rb2D;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 0) { return; }

        if (collision.gameObject.tag == "Gravity_button")
        {
            _rb2D.gravityScale *= -1;
        }
        if (collision.gameObject.tag == "Lucio")
        {
            _speed *= 1.6f;
        }
        else if (collision.gameObject.tag == "Slow")
        {
            _speed *= 0.6f;
        }
        else if (collision.gameObject.tag == "Reverse")
        {
            _speed *= -1;
        }else if (collision.gameObject.tag == "Jump") {
            _rb2D.AddForce(Vector2.up * _jumpHeight * Time.deltaTime,ForceMode2D.Impulse);
        }
        else if (collision.gameObject.tag == "StrongJump")
        {
            _rb2D.AddForce(Vector2.up * _jumpHeight * 1.1f * Time.deltaTime, ForceMode2D.Impulse);

        }
    }
    private void Start()
    {
        //_speed = new Vector3(0, 0, 0);
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(_speed* Time.deltaTime, _rb2D.velocity.y);
    }
    public void Left(float num)
    {
        _speed = num;
    }

    public void right(float num)
    {
        _speed = num;
    }
}
