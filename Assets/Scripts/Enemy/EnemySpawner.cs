using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyStateManger enemy;
    IObjectPool<EnemyStateManger> enemyPool;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemyPool.Get();
        }
    }
}
