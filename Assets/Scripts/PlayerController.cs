using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _collider;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate() {
        _rigidbody.velocity = new Vector2(playerSpeed, _rigidbody.velocity.y);
    }
}
