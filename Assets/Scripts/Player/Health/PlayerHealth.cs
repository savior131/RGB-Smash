using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] ParticleSystem explotion;
    public event Action onHealthChange;

    public void decreaseHealth()
    {
        health--;
        if (onHealthChange != null) onHealthChange();
        if (health < 1)
        {
            explotion.transform.position = transform.position;
            explotion.Play();
            Destroy(gameObject);
        }
    }

    public int getPlayerHealth()
    {
        return health;
    }
}
