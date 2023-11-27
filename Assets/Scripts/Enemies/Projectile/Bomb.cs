using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float forceX;
    [SerializeField] private float forceY;
    [SerializeField] private int damage;
    [SerializeField] private GameObject bombExplosion;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(new Vector2(forceX,forceY), ForceMode2D.Impulse);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player.OnHit(damage);
            GameObject explosion = Instantiate(bombExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 0.5f);
        }
    }
}
