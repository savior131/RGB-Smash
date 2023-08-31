using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;

    public event Action onHealthChange;

    public void decreaseHealth()
    {
        health--;
        if (onHealthChange != null) onHealthChange();
        if(health < 1) Destroy(gameObject);
    }

    public int getPlayerHealth()
    {
        return health;
    }
}
