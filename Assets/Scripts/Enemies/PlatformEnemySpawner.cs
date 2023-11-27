using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject currentEnemy;
    [SerializeField] List<Transform> points = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Destroy(currentEnemy);
        }
    }

    public void Spawn(){
        if(currentEnemy.Equals(null) ){
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        int pos = Random.Range(0,points.Count);
        GameObject enemy = Instantiate(enemyPrefab, points[pos].position, points[pos].rotation);
        currentEnemy = enemy;
    }
}
