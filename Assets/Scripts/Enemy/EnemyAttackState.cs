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
#pragma warning disable CS0612 // Type or member is obsolete
        particalEffectManger.enemyTrailPartical(enemy.transform,enemyColor.GlowColor);
#pragma warning restore CS0612 // Type or member is obsolete
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

    public override void setupWhenCollsion(EnemyStateManger enemy, Collision2D collision , PlayerScore score, PlayerStateController playerColor, AudioPlayer audioPlayer)
    {
        enemyRb.AddForce(force * enemyRb.velocity, ForceMode2D.Impulse);
        Camera.main.GetComponent<CameraShake>().Shake(0.1f, 1f, 5);
        if (collision.gameObject.tag == "Player")
        {   
            if (playerColor.getPlayerColor() == Color.red && currentEnemyColor.r == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
                score.increaseScore();
                score.increaseCompo();
            }
            else if (playerColor.getPlayerColor() == Color.green && currentEnemyColor.g == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
                score.increaseScore();
                score.increaseCompo();
            }
            else if (playerColor.getPlayerColor() == Color.blue && currentEnemyColor.b == 1)
            {
                enemy.swichEnemyState(enemy.enemyDestroyState);
                score.increaseScore();
                score.increaseCompo();
            }
            else
            {
                GameObject player = GameObject.FindGameObjectWithTag("Health Manager");
                player.GetComponent<PlayerHealth>().decreaseHealth();
                enemy.swichEnemyState(enemy.enemyDestroyState);
                score.resetCompo();
            }
            audioPlayer.playDestoryEnemyEffect();
            Camera.main.GetComponent<CameraShake>().Shake(0.3f, 1.8f, 20);
        }
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, force);
    }

}
