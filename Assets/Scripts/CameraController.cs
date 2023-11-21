using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    [SerializeField]
    private float camSpeed;
    [SerializeField]
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCamPos = new Vector3(playerTransform.position.x + offset, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, camSpeed * Time.deltaTime);
    }
}
