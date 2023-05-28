using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2D : MonoBehaviour
{
    public float moveSpeed = 5f;  // The speed at which the player moves

    private SpriteRenderer spriteRenderer;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private Animator anim;

    [SerializeField]
    private float _jumpHeight = 15f;
    [SerializeField]
    private float _groundDetectRange = 0.5f;

    [SerializeField]
    private bool isGrounded;
    private bool isJumping, _resetJump;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = IsGrounded();
        if (GameManager.Instance.Player2DCanControl == false)
            return;
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            isJumping = true;
            anim.SetBool("isJumping", isJumping);
            StartCoroutine(ResetJumpRoutine());
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.Player2DCanControl == false)
            return;
        
        Movement();
    }

    private void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        Fliping(moveX);
        Vector3 movement = new Vector3(moveX, 0f, 0f) * moveSpeed * Time.deltaTime;
        anim.SetFloat("Running", Mathf.Abs(moveX));
        _rigidbody.MovePosition(transform.position + movement);

        if (isJumping)
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _jumpHeight, _rigidbody.velocity.z);
            isJumping = false;
        }
    }

    private bool IsGrounded()
    {
        bool hit = Physics.Raycast(transform.position, Vector3.down, _groundDetectRange, 1 << 6);
        if(hit)
        {
            if(!_resetJump)
            {
                anim.SetBool("isJumping", isJumping);
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    private void Fliping(float moveHorizontal)
    {
        if (moveHorizontal != 0)
        {
            bool isFliping = moveHorizontal > 0 ? false : true;
            spriteRenderer.flipX = isFliping;
        }
    }
}
