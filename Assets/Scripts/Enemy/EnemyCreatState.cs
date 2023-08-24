using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyCreatState : EnemyBaseState
{
    #region colors
    Color[] colors = { new Color(1f, 0f, 0f) , new Color(0f, 1f, 0f), new Color(0f, 0f, 1f) };
    Color[] colorsSmallCircle = { new Color(0.2f, 0f, 0f), new Color(0f, 0.2f, 0f), new Color(0f, 0f, 0.2f) };
    #endregion
    #region scale
    Vector3 growScale = new Vector3(0.1f, 0.1f, 0.1f);
    float growSpeed = 7f;
    #endregion
    int colorIndex = 0;
    public override void setupStart(EnemyStateManger enemy,SpriteGlowEffect enemyColor,
                                    SpriteRenderer smallCircleInEnemy,ParticalEffectManger particalEffectManger)
    {
        setReferance(enemy, out enemyColor, out smallCircleInEnemy, out particalEffectManger);
        setColorEnemy(enemy, enemyColor, smallCircleInEnemy, particalEffectManger);
        enemy.transform.localScale = growScale;
    }

    private void setColorEnemy(EnemyStateManger enemy, SpriteGlowEffect enemyColor, SpriteRenderer smallCircleInEnemy, ParticalEffectManger particalEffectManger)
    {
        colorIndex = Random.Range(0, colors.Length);
        enemyColor.GlowColor = colors[colorIndex];
        smallCircleInEnemy.color = colorsSmallCircle[colorIndex];
        particalEffectManger.releasCreatEnemyPartical(enemy.transform, colors[colorIndex]);
    }

    private static void setReferance(EnemyStateManger enemy, out SpriteGlowEffect enemyColor, out SpriteRenderer smallCircleInEnemy, out ParticalEffectManger particalEffectManger)
    {
        enemyColor = enemy.GetComponent<SpriteGlowEffect>();
        particalEffectManger = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
        smallCircleInEnemy = enemy.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public override void setupUpdate(EnemyStateManger enemy)
    {
        if (enemy.transform.localScale.x <= 1.4f)
            enemy.transform.localScale += growScale * Time.deltaTime * growSpeed;
        else
            enemy.swichEnemyState(enemy.enemyAttackState);
    }

    public override void setupWhenCollsion(EnemyStateManger enemy)
    {
        
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {

    }
}
