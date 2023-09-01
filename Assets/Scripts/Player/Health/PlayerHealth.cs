using SpriteGlow;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] ParticleSystem explotion;
    [SerializeField] SpriteGlowEffect playerSprite;
    public event Action onHealthChange;
    bool canDamegePlayer = true;
    [SerializeField] UnityEvent onPlayerDeath;
    public void decreaseHealth()
    {
        if (canDamegePlayer)
        {
            health--;
            if (onHealthChange != null) onHealthChange();
            if (health < 1)
            {
                explotion.transform.position = transform.position;
                explotion.Play();
                Destroy(gameObject);
                Invoke("playerDeath", 1f);
            }
            StartCoroutine(coolDown());
        }
    }

    void playerDeath()
    {
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
