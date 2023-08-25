using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody2D enemyRb;
    float force = 10;
    public override void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor 
        , SpriteRenderer smallCircleInEnemy , ParticalEffectManger particalEffectManger)
    {
        enemyRb = enemy.GetComponent<Rigidbody2D>();
        addForseForCircle();
    }

    void addForseForCircle()
    {
        float forceX = Random.Range(-100, 100);
        float forceY = Random.Range(-100, 100);
        enemyRb.AddForce(new Vector2(forceX / 100, forceY / 100).normalized * force , ForceMode2D.Impulse);
        enemyRb.velocity = Vector2.ClampMagnitude(enemyRb.velocity,force);
    }

    public override void setupUpdate(EnemyStateManger enemy)
    {
        
    }

    public override void setupWhenCollsion(EnemyStateManger enemy)
    {

    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {
        
    }

}
