using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length;
    private float initialPosition;
    [SerializeField] private Transform cam;
    [SerializeField] private float parallaxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float reposition = cam.transform.position.x * (1 - parallaxSpeed);
        float distance = cam.transform.position.x * parallaxSpeed;
        transform.position = new Vector3(initialPosition + distance, transform.position.y, transform.position.z);

        if(reposition > initialPosition + length){
            initialPosition += length;
        }
    }
}
