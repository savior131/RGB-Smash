using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyDestroyState : EnemyBaseState
{
    

    public override void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor,
        ParticalEffectManger particalEffectManger , IObjectPool<EnemyStateManger> enemyPool)
    {
        setReferance(enemy, out enemyColor, out particalEffectManger);
        GameObject.Destroy(enemy.transform.GetChild(0).gameObject);
#pragma warning disable CS0612 // Type or member is obsolete
        particalEffectManger.enemyDestroyPartical(enemy.transform, enemyColor.GlowColor);
#pragma warning restore CS0612 // Type or member is obsolete
        enemyPool.Release(enemy);
    }
    private static void setReferance(EnemyStateManger enemy, out SpriteGlowEffect enemyColor, out ParticalEffectManger particalEffectManger)
    {
        enemyColor = enemy.GetComponent<SpriteGlowEffect>();
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
    }

    public override void setupUpdate(EnemyStateManger enemy)
    {
        
    }
    public override void setupFixedUpdate(EnemyStateManger enemy)
    {

    }
    public override void setupWhenCollsion(EnemyStateManger enemy, Collision2D collision, PlayerScore score, PlayerStateController playerColor, AudioPlayer audioPlayer)
    {
        
    }

}
