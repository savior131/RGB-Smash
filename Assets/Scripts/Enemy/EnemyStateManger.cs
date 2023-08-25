using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManger : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyCreatState enemyCreatState = new EnemyCreatState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    SpriteGlowEffect enemyColor;
    SpriteRenderer smallCircleInEnemy;
    ParticalEffectManger particalEffectManger;

    private void OnEnable()
    {
        currentState = enemyCreatState;
        enemyCreatState.setupStart(this, enemyColor, smallCircleInEnemy , particalEffectManger);
    }

    private void Update()
    {
        currentState.setupUpdate(this);
    }

    private void FixedUpdate()
    {
        currentState.setupFixedUpdate(this);
    }

    public void swichEnemyState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.setupStart(this, enemyColor, smallCircleInEnemy, particalEffectManger);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.setupWhenCollsion(this);
    }

}
