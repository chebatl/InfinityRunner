using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] protected int damage;
    public float speed;


    public virtual void TakeDamage(int value){
        health -= value;
        if(health <= 0){
            Destroy(gameObject);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Projectile")){
            TakeDamage(other.GetComponent<Bullet>().damage);
            other.GetComponent<Bullet>().OnHit();
        }
    }
}
