using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManger enemy;
    IObjectPool<EnemyStateManger> enemyPool;
    float spawnTimer=20;
    int enemyCount=6;
    bool StillSpawning = true;
    private void Awake()
    {
        
        enemyPool = new ObjectPool<EnemyStateManger>(createEnemy , OnGet , OnReleas);
    }
    private EnemyStateManger createEnemy()
    {
        EnemyStateManger newEnemy = Instantiate(enemy);
        newEnemy.setEnemyInPool(enemyPool);
        return newEnemy;
    }
    private void OnGet(EnemyStateManger enemy)
    {
        enemy.gameObject.SetActive(true);
    }
    private void OnReleas(EnemyStateManger enemy)
    {
        enemy.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartCoroutine(waitBeforeCreate());
        
    }
    private void Update()
    {

        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Enemy");
        bool allDisabled = true;
        foreach (GameObject obj in taggedObjects)
        {
            if (obj.activeSelf)
            {
                allDisabled = false;
                break; 
            }
        }
        if (allDisabled&&!StillSpawning)
        {
            allDisabled = false;
            enemyCount += 1;
            spawnTimer = (spawnTimer > 5) ? spawnTimer - 0.1f : 5;
            StopAllCoroutines();
            StartCoroutine(spawner());
        }
            
    }
    IEnumerator spawner()
    {
        while (true)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                enemyPool.Get();
            }
            yield return new WaitForSeconds(spawnTimer);
            enemyCount += 1;
            spawnTimer = (spawnTimer > 5) ? spawnTimer - 0.1f : 5;     
        }
    }
    IEnumerator waitBeforeCreate()
    {
        StillSpawning = true;
        yield return new WaitForSeconds(1f);
        StillSpawning = false;
        StartCoroutine(spawner());
    }
}
