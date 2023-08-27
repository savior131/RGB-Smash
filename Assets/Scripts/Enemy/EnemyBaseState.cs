using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void setupStart(EnemyStateManger enemy, SpriteGlowEffect enemyColor
        , ParticalEffectManger particalEffectManger);
    public abstract void setupUpdate(EnemyStateManger enemy);
    public abstract void setupFixedUpdate(EnemyStateManger enemy);

    public abstract void setupWhenCollsion(EnemyStateManger enemy);

}

