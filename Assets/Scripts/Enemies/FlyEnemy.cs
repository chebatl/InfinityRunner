using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{

    private Rigidbody2D _rigbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigbody = GetComponent<Rigidbody2D>();
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
}
