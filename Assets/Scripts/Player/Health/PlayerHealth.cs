using SpriteGlow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;

    public event Action onHealthChange;

    AudioPlayer audioPlayer;

    [SerializeField] SpriteGlowEffect playerSprite;
    bool canDamegePlayer = true;
    private void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
    }
    private void Update()
    {
        Debug.Log(canDamegePlayer);
    }
    public void decreaseHealth()
    {
        if (canDamegePlayer)
        {
            health--;
            if (onHealthChange != null) onHealthChange();
            if (health < 1)
            {
                audioPlayer.playDestoryPlayerEffect();
                Destroy(gameObject);
            }
            audioPlayer.playPlayerHeartEffect();
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
        canDamegePlayer= true;
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
