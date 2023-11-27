using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{

    private Rigidbody2D _rigbody;
    private PlayerController player;
    
    [SerializeField] private GameObject bombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        _rigbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine(Recycle());
    }

    IEnumerator Recycle(){
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _rigbody.velocity = Vector2.left * speed;
    }

    protected override void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player.OnHit(damage);
            GameObject explosion = Instantiate(bombExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 0.5f);
        }

       if(other.CompareTag("Projectile")){
           TakeDamage(other.GetComponent<Bullet>().damage);
           other.GetComponent<Bullet>().OnHit();
       }
    }
}
