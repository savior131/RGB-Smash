using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyStateManger : MonoBehaviour
{
    EnemyBaseState currentState;
    public EnemyCreatState enemyCreatState = new EnemyCreatState();
    public EnemyAttackState enemyAttackState = new EnemyAttackState();
    public EnemyDestroyState enemyDestroyState = new EnemyDestroyState();
    SpriteGlowEffect enemyColor;
    ParticalEffectManger particalEffectManger;
    IObjectPool<EnemyStateManger> enemyPool;
    float randomX, randomY;
    PlayerScore score;
    PlayerStateController playerColor;
    AudioPlayer audioplayer;
    private void OnEnable()
    {
        currentState = enemyCreatState;
        enemyCreatState.setupStart(this, enemyColor, particalEffectManger, enemyPool);
        setRandomPosition();
        if(GameObject.FindGameObjectWithTag("Player"))
        {
            score = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScore>();
            playerColor = GameObject.FindGameObjectWithTag("Trail").GetComponent<PlayerStateController>();
            audioplayer = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
        }
    }

    private void setRandomPosition()
    {
        float cameraHeight = Camera.main.orthographicSize * 2f;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        Vector2 cameraPosition = Camera.main.transform.position;

        // Calculate random spawn point within the camera boundaries
        randomX = Random.Range(cameraPosition.x - cameraWidth / 2f, cameraPosition.x + cameraWidth / 2f);
        randomY = Random.Range(cameraPosition.y - cameraHeight / 2f, cameraPosition.y + cameraHeight / 2f);
        transform.position = new Vector3(randomX, randomY, 0);
    }

    private void Update()
    {
        currentState.setupUpdate(this);
    }

    private void FixedUpdate()
    {
        currentState.setupFixedUpdate(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentState.setupWhenCollsion(this, collision , score , playerColor , audioplayer);
    }

    public void swichEnemyState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.setupStart(this, enemyColor, particalEffectManger , enemyPool);
    }

    public void setEnemyInPool(IObjectPool<EnemyStateManger> pool)
    {
        enemyPool = pool;
    }
}
