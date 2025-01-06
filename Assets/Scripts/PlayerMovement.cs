using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSspeed = 0.1f;
    [SerializeField] private float jumpForce = 7.0f;
    [SerializeField] private AudioSource jumpSoundEffect;

    private enum MovementState
    {
        idle, running, jumping, falling
    }

    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator animator;
    private bool isGrounded = false;
    private MovementState _movementState
    {
        get { return (MovementState)animator.GetInteger("state"); }
        set { animator.SetInteger("state", (int)value); }
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
            isGrounded = true;
    }
    void Update()
    {
        if (_rb.velocity.y < -.1f)
        {
            _movementState = MovementState.falling;
            isGrounded = false;
        }

        if (isGrounded && _rb.bodyType != RigidbodyType2D.Static)
            _movementState = MovementState.idle;

        if (Input.GetButton("Horizontal") && _rb.bodyType != RigidbodyType2D.Static)
            Run();

        if (Input.GetButtonDown("Jump") && isGrounded)
            Jump();
    }
    private void Jump()
    {
        jumpSoundEffect.Play();
        isGrounded = false;
        _movementState = MovementState.jumping;
        _rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    private void Run()
    {
        var dir = Input.GetAxis("Horizontal");

        if(isGrounded)
         _movementState = MovementState.running;

        _spriteRenderer.flipX = dir < 0f;
        transform.Translate(new Vector2(dir * movementSspeed, 0));
    }
}
