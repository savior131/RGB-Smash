using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyState : EnemyBaseState
{
    

    public override void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor, ParticalEffectManger particalEffectManger)
    {
        setReferance(enemy, out enemyColor, out particalEffectManger);
        particalEffectManger.enemyDestroyPartical(enemy.transform, enemyColor.GlowColor);
        GameObject.Destroy(enemy.gameObject);
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
