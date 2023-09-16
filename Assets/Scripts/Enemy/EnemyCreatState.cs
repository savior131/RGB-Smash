using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Pool;

public class EnemyCreatState : EnemyBaseState 
{
    #region colors
    Color[] colors = { Color.red , Color.green, Color.blue};
    #endregion
    #region scale
    Vector3 growScale = new Vector3(0.1f, 0.1f, 0.1f);
    float growSpeed = 7f;
    #endregion
    int colorIndex = 0;
    float randomX, randomY;
    float cameraHeight;
    float cameraWidth; 
    Vector2 rangeX,rangeY;

    public override void setupStart(EnemyStateManger enemy,SpriteGlowEffect enemyColor,
                                   ParticalEffectManger particalEffectManger , IObjectPool<EnemyStateManger> enemyPool)
    {
        cameraHeight = Camera.main.orthographicSize * 2f;
        cameraWidth = cameraHeight * Camera.main.aspect;
        rangeX = new((-cameraWidth / 2f) + 5, (cameraWidth / 2f) - 5);
        rangeY = new((-cameraHeight / 2f) + 5, (cameraHeight / 2f) - 5);
        setRandomPosition(enemy);
        setColorEnemy(enemy, enemyColor, particalEffectManger);
        enemy.transform.localScale = growScale;
        enemy.GetComponent<CircleCollider2D>().enabled = false;
        if(enemy.transform.childCount > 0)
        {
            GameObject.Destroy(enemy.transform.GetChild(0).gameObject);
        }
    }
    private void setRandomPosition(EnemyStateManger enemy)
    {
        Vector2 cameraPosition = Camera.main.transform.position;

        // Calculate random spawn point within the camera boundaries
        randomX = Random.Range(rangeX.x,rangeX.y);
        randomY = Random.Range(rangeY.x,rangeY.y);
        enemy.transform.position = new Vector3(randomX, randomY, 0);
    }
    private void setColorEnemy(EnemyStateManger enemy, SpriteGlowEffect enemyColor, ParticalEffectManger particalEffectManger)
    {
        colorIndex = Random.Range(0, colors.Length);
        enemyColor.GlowColor = colors[colorIndex];
#pragma warning disable CS0612 // Type or member is obsolete
        particalEffectManger.releaseCreateEnemyPartical(enemy.transform, colors[colorIndex]);
#pragma warning restore CS0612 // Type or member is obsolete
    }
    public override void setupWhenCollsion(EnemyStateManger enemy , Collision2D collision , PlayerScore score, PlayerStateController playerColor, AudioPlayer audioPlayer, EnemySpawner enemySpawner)
    {
        
        
    }

    public override void setupFixedUpdate(EnemyStateManger enemy)
    {
        if (enemy.transform.localScale.x <= 1.2f)
            enemy.transform.localScale += growScale * Time.deltaTime * growSpeed;
        else
            enemy.swichEnemyState(enemy.enemyAttackState);
    }

}
