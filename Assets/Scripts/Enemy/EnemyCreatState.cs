using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Pool;

public class EnemyCreatState : EnemyBaseState 
{
    #region colors
    Color[] colors = {Color.red , Color.green, Color.blue};
    #endregion
    #region scale
    Vector3 growScale = new Vector3(0.1f, 0.1f, 0.1f);
    float growSpeed = 7f;
    #endregion
    int colorIndex = 0;
    public override void setupStart(EnemyStateManger enemy,SpriteGlowEffect enemyColor,
                                   ParticalEffectManger particalEffectManger , IObjectPool<EnemyStateManger> enemyPool)
    {
        setReferance(enemy, out enemyColor, out particalEffectManger);
        setColorEnemy(enemy, enemyColor, particalEffectManger);
        enemy.transform.localScale = growScale;
        enemy.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void setColorEnemy(EnemyStateManger enemy, SpriteGlowEffect enemyColor, ParticalEffectManger particalEffectManger)
    {
        colorIndex = Random.Range(0, colors.Length);
        enemyColor.GlowColor = colors[colorIndex];
        particalEffectManger.releaseCreateEnemyPartical(enemy.transform, colors[colorIndex]);
    }

    private static void setReferance(EnemyStateManger enemy, out SpriteGlowEffect enemyColor, out ParticalEffectManger particalEffectManger)
    {
        enemyColor = enemy.GetComponent<SpriteGlowEffect>();
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
        
    }

    public override void setupUpdate(EnemyStateManger enemy)
    {
        if (enemy.transform.localScale.x <= 1.4f)
            enemy.transform.localScale += growScale * Time.deltaTime * growSpeed;
        else
            enemy.swichEnemyState(enemy.enemyAttackState);
    }

    public override void setupWhenCollsion(EnemyStateManger enemy , Collision2D collision)
    {
        
        
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {

    }

}
