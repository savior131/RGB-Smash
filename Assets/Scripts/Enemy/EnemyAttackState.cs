using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody2D enemyRb;
    float force = 10;
    Color currentEnemyColor;
    public override void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor 
         , ParticalEffectManger particalEffectManger , IObjectPool<EnemyStateManger> enemyPool)
    {
        enemy.GetComponent<CircleCollider2D>().enabled = true;
        enemyRb = enemy.GetComponent<Rigidbody2D>();
        setReferance(enemy, out enemyColor, out particalEffectManger);
        addForseForCircle();
        particalEffectManger.enemyTrailPartical(enemy.transform,enemyColor.GlowColor);
        currentEnemyColor = enemyColor.GlowColor;
    }

    void addForseForCircle()
    {
        float forceX = Random.Range(-100, 100);
        float forceY = Random.Range(-100, 100);
        enemyRb.AddForce(new Vector2(forceX / 100, forceY / 100).normalized * force, ForceMode2D.Impulse);
    }
    private static void setReferance(EnemyStateManger enemy, out SpriteGlowEffect enemyColor, out ParticalEffectManger particalEffectManger)
    {
        enemyColor = enemy.GetComponent<SpriteGlowEffect>();
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
        
    }
    public override void setupUpdate(EnemyStateManger enemy)
    {

    }

    public override void setupWhenCollsion(EnemyStateManger enemy, Collision2D collision)
    {
        enemyRb.AddForce(force * enemyRb.velocity, ForceMode2D.Impulse);
        Camera.main.GetComponent<CameraShake>().Shake(0.1f, 1f, 5);
        if (collision.gameObject.tag == "Player")
        {
            GameObject trail = GameObject.FindGameObjectWithTag("Trail");
            if (trail.GetComponent<PlayerStateController>().getPlayerColor() == "red" && currentEnemyColor.r == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
            }
            else if (trail.GetComponent<PlayerStateController>().getPlayerColor() == "green" && currentEnemyColor.g == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
            }
            else if (trail.GetComponent<PlayerStateController>().getPlayerColor() == "blue" && currentEnemyColor.b == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
            }
            else
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.GetComponent<PlayerHealth>().decreaseHealth();
                enemy.swichEnemyState(enemy.enemyDestroyState);
            }
            Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
        }
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, force);
    }

}
