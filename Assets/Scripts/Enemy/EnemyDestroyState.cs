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
        particalEffectManger.enemyDestroyPartical(enemy.transform, enemyColor.GlowColor);
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
    public override void setupWhenCollsion(EnemyStateManger enemy, Collision2D collision)
    {
        
    }

}
