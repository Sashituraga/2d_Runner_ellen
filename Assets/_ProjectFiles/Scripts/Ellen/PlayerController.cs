using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public Rigidbody2D rigidbody2D;
    public int jumpSpeed;
    [SerializeField] private int _Speed;
    private bool isGrounded = false;

    private void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        //float jump = Input.GetAxisRaw("Jump");

        MovePlayer(horizontalMove);

        Vector3 localScale = transform.localScale;

        // if (jump > 0) _animator.SetBool("CanJump", true);
        // else _animator.SetBool("CanJump", false);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) JumpPlayer();
            isGrounded = false;
        }
        if (horizontalMove > 0)
        {
            _animator.SetBool("isrunning", true);
            localScale.x = Mathf.Abs(localScale.x);
        }
        else if (horizontalMove < 0)
        {
            _animator.SetBool("isrunning", true);
            localScale.x = -1f * Mathf.Abs(localScale.x);
        }
        else
        {
            _animator.SetBool("isrunning", false);
        }
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            isGrounded = true;
            _animator.SetBool("CanJump", false);
        }
    }
    private void MovePlayer(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * _Speed * Time.deltaTime;
        transform.position = position;
    }
    private void JumpPlayer()
    {
        rigidbody2D.velocity = Vector2.up * jumpSpeed;
        _animator.SetBool("CanJump", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "SKIPSCENE")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
   
