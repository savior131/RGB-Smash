using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManger enemy;
    IObjectPool<EnemyStateManger> enemyPool;
    float spawnTimer=20;
    int enemyCount=6;
    bool StillSpawning = true;
    private int activeEnemyCount = 0;
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
        if (activeEnemyCount == 0 && !StillSpawning)
        {
            enemyCount += 1;
            spawnTimer = (spawnTimer > 10) ? spawnTimer - 0.02f : 10;
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
                IncreaseEnemyCount();
                enemyPool.Get();
            }
            yield return new WaitForSeconds(spawnTimer);
            enemyCount += 1;
            spawnTimer = (spawnTimer > 10) ? spawnTimer - 0.5f : 10;
        }
    }
    IEnumerator waitBeforeCreate()
    {
        StillSpawning = true;
        yield return new WaitForSeconds(1f);
        StillSpawning = false;
        StartCoroutine(spawner());
    }
    private void IncreaseEnemyCount()
    {
        activeEnemyCount++;
    }

    public void DecreaseEnemyCount()
    {
        activeEnemyCount--;
    }

}
