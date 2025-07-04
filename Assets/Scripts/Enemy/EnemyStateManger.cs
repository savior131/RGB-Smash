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
    #endregion

    IObjectPool<EnemyStateManger> enemyPool;
    private void OnEnable()
    {
        currentState = enemyCreatState;
        setRefrence();
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
        enemyColor = GetComponent<SpriteGlowEffect>();
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
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
        currentState.setupWhenCollsion(this, collision , score , playerColor , audioplayer);
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
