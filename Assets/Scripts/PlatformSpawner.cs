using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public List<GameObject> platformsList = new List<GameObject>(); //prefabs
    private List<Transform> currentPlatformsList = new List<Transform>(); //objetos na cena
    private Transform player;

    private Transform currentPlatform;
    private int platformIndex;

    [SerializeField]
    private float offsetX;
    [SerializeField]
    private float offsetY;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;

        foreach (GameObject platform in platformsList)
        {
            Transform aux = Instantiate(platform, new Vector2(offsetX, offsetY), transform.rotation).transform;
            currentPlatformsList.Add(aux);
            offsetX += 30;
        }
    }

    

    private void Update() {
        Move();
    }

    private void Move(){
        float distance = player.position.x - getCurrentPlatformX();
        if(distance >= 5 ){
            Pooling(currentPlatformsList[platformIndex++].gameObject);
            if(platformIndex > currentPlatformsList.Count -1){
                platformIndex = 0;
            }
        }
    }

    private float getCurrentPlatformX()
    {
        return currentPlatformsList[platformIndex].GetComponent<Platform>().platformEnd.position.x;
    }

    public void Pooling(GameObject platform){
        platform.transform.position = new Vector2(offsetX, offsetY);
        offsetX+=30;
    }
}
