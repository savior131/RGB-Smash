using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyStateManger : MonoBehaviour
{
    #region Enemy states
    EnemyBaseState currentState;
    public EnemyCreatState enemyCreatState = new EnemyCreatState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyDestroyState enemyDestroyState = new EnemyDestroyState();
    #endregion
    #region refrance script
    SpriteGlowEffect enemyColor;
    ParticalEffectManger particalEffectManger;
    PlayerScore score;
    PlayerStateController playerColor;
    AudioPlayer audioplayer;
    EnemySpawner enemySpawner;
    #endregion

    IObjectPool<EnemyStateManger> enemyPool;

    private void Awake()
    {
        setRefrence();
    }
    private void OnEnable()
    {
        currentState = enemyCreatState;
        enemyCreatState.setupStart(this, enemyColor, particalEffectManger, enemyPool);
    }

    private void setRefrence()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            score = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
            playerColor = GameObject.FindGameObjectWithTag("Trail").GetComponent<PlayerStateController>();
            audioplayer = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
        }
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
        enemySpawner=GameObject.FindGameObjectWithTag("Enemy Spawner").GetComponent<EnemySpawner>();
        enemyColor = GetComponent<SpriteGlowEffect>();
    }

    private void FixedUpdate()
    {
        currentState.setupFixedUpdate(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.setupWhenCollsion(this, collision , score , playerColor , audioplayer,enemySpawner);
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
