using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManger enemy;
    IObjectPool<EnemyStateManger> enemyPool;
    float spawnTimer=20;
    int enemyCount=6;
    bool incrimentEnemyCount=false;
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
        StartCoroutine(spawner());
    }
    IEnumerator spawner()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            enemyPool.Get();
        }
        yield return new WaitForSeconds(spawnTimer);
        incrimentEnemyCount = !incrimentEnemyCount;
        enemyCount = (incrimentEnemyCount) ? enemyCount + 1 : enemyCount;
        spawnTimer = (spawnTimer > 5) ? spawnTimer - 0.1f : 5;
        StartCoroutine(spawner());
    }
}
