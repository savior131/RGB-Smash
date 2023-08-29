using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyStateManger : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyCreatState enemyCreatState = new EnemyCreatState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyDestroyState enemyDestroyState = new EnemyDestroyState();
    SpriteGlowEffect enemyColor;
    ParticalEffectManger particalEffectManger;
    IObjectPool<EnemyStateManger> enemyPool;
    int randX, randY;
    private void OnEnable()
    {
        currentState = enemyCreatState;
        enemyCreatState.setupStart(this, enemyColor , particalEffectManger, enemyPool);
        randX = Random.Range(0, 24);
        randY = Random.Range(0, 12);
        transform.position = new Vector3(randX, randY, 0);
    }

    private void Update()
    {
        currentState.setupUpdate(this);
    }

    private void FixedUpdate()
    {
        currentState.setupFixedUpdate(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.setupWhenCollsion(this, collision);
    }

    public void swichEnemyState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.setupStart(this, enemyColor, particalEffectManger , enemyPool);
    }

    public void setEnemyInPool(IObjectPool<EnemyStateManger> pool)
    {
        enemyPool = pool;
    }
}
