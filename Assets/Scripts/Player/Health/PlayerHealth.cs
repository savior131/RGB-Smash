using SpriteGlow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] SpriteGlowEffect playerSprite;
    [SerializeField] UnityEvent onPlayerDeath;
    [SerializeField] Transform player;
    ParticalEffectManger plarticalEffect;
    bool canDamegePlayer = true;
    public event Action onHealthChange;
    AudioPlayer audioPlayer;
    

    private void Start()
    {
        plarticalEffect = GameObject.FindGameObjectWithTag("Partical Manger").GetComponent<ParticalEffectManger>();
        audioPlayer = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
    }
    public void decreaseHealth()
    {
        if (canDamegePlayer)
        {
            health--;
            audioPlayer.playPlayerHeartEffect();
            if (onHealthChange != null) onHealthChange();
            if (health < 1)
            {
                audioPlayer.playDestoryPlayerEffect();
                plarticalEffect.destoryPlayerPartical(player);
                StartCoroutine(playerDeath());
                Destroy(player.gameObject);
                
            }
            StartCoroutine(coolDown());
        }
    }

    IEnumerator playerDeath()
    {
        Debug.Log("gameover");
        yield return new WaitForSeconds(1f);
        onPlayerDeath.Invoke();
    }

    public int getPlayerHealth()
    {
        return health;
    }
    IEnumerator coolDown()
    {
        canDamegePlayer = false;
        StartCoroutine(coolDownEffect());
        yield return new WaitForSeconds(1.5f);
        StopAllCoroutines();
        playerSprite.AlphaThreshold = 1;
        canDamegePlayer = true;
    }

    IEnumerator coolDownEffect()
    {
        while (true)
        {
            playerSprite.AlphaThreshold = 0;
            yield return new WaitForSeconds(0.1f);
            playerSprite.AlphaThreshold = 1;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
