using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;

    public event Action onHealthChange;

    AudioPlayer audioPlayer;

    private void Start()
    {
        audioPlayer = GameObject.FindGameObjectWithTag("Audio Player").GetComponent<AudioPlayer>();
    }

    public void decreaseHealth()
    {
        health--;
        if (onHealthChange != null) onHealthChange();
        if (health < 1)
        {
            audioPlayer.playDestoryPlayerEffect();
            Destroy(gameObject);
        }
        audioPlayer.playPlayerHeartEffect();
    }

    public int getPlayerHealth()
    {
        return health;
    }
}
