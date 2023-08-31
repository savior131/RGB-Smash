using SpriteGlow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class EnemyBaseState
{
    public abstract void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor
        , ParticalEffectManger particalEffectManger , IObjectPool<EnemyStateManger> enemyPool);
    public abstract void setupUpdate(EnemyStateManger enemy);
    public abstract void setupFixedUpdate(EnemyStateManger enemy);

    public abstract void setupWhenCollsion(EnemyStateManger enemy , Collision2D collision , PlayerScore score , PlayerStateController playerColor);

}

