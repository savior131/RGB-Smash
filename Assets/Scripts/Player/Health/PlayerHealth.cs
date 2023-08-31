using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    public void decreaseHealth()
    {
        health--;
        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
}
