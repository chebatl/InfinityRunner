using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> enemiesList = new List<GameObject>();
    private float timeCount;
    [SerializeField] private float spawnTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if(timeCount >= spawnTime){
            SpawEnemy();
            timeCount = 0f;
        }
    }

    void SpawEnemy(){
        Instantiate(enemiesList[Random.Range(0,enemiesList.Count)], transform.position + new Vector3(0, Random.Range(-4f,2f), 0), transform.rotation);
    }
}
