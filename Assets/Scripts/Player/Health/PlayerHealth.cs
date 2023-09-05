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
    [SerializeField] ParticalEffectManger plarticalEffect;
    bool canDamegePlayer = true;
    public event Action onHealthChange;
    [SerializeField] AudioPlayer audioPlayer;
    
    public void decreaseHealth()
    {
        if (canDamegePlayer)
        {
            health--;
            audioPlayer.playPlayerHeartEffect();
            if (onHealthChange != null) onHealthChange();
            if (health < 1)
            {
                Destroy(this.gameObject);
                audioPlayer.playDestoryPlayerEffect();
#pragma warning disable CS0612 // Type or member is obsolete
                plarticalEffect.destoryPlayerPartical(gameObject.transform);
#pragma warning restore CS0612 // Type or member is obsolete
            }
            StartCoroutine(coolDown());
        }
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
