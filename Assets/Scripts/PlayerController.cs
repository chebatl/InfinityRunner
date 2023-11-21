using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    private bool onGround = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if(onGround && Input.GetKeyDown(KeyCode.Space)){
            onGround = !onGround;
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpForce), ForceMode2D.Impulse);
            _animator.SetBool("onGround", onGround);
        }
    }

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector2(playerSpeed, _rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        onGround = other.gameObject.layer == 3;
        // onGround = other.gameObject.ComparTag("Ground");
        _animator.SetBool("onGround", onGround);
    }
}
