using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody2D enemyRb;
    CameraShake shake;
    float force = 10;
    public override void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor 
         , ParticalEffectManger particalEffectManger)
    {
        enemyRb = enemy.GetComponent<Rigidbody2D>();
        shake= Camera.allCameras[0].GetComponent<CameraShake>();
        setReferance(enemy, out enemyColor, out particalEffectManger);
        addForseForCircle();
        particalEffectManger.enemyTrailPartical(enemy.transform,enemyColor.GlowColor);
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

    public override void setupWhenCollsion(EnemyStateManger enemy)
    {
        enemyRb.AddForce(force * enemyRb.velocity, ForceMode2D.Impulse);
        shake.Shake(0.1f, 0.6f,5);
        
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, force);
    }
}
