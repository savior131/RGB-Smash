using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ParticleSystemJobs;
public class ColorCollector : MonoBehaviour
{
    PlayerStateController playerStateController;
    float maxCapacitis = 5f;
    float[] RGBCapacitis = { 2.5f, 2.5f, 2.5f };
    float amountCollected = 0.01f;
    float ammountDrained = 0.01f;
    [SerializeField] UnityEvent colorChange;

    public event Action onRedCollect;
    public event Action onGreenCollect;
    public event Action onBlueCollect;
    public void redCollect()
    {
        RGBCapacitis[0] += amountCollected;
    }
    public void greenCollect()
    {
        RGBCapacitis[1] += amountCollected;
    }
    public void blueCollect()
    {
        RGBCapacitis[2] += amountCollected;
    }
    private void Start()
    {
        playerStateController = GameObject.FindGameObjectWithTag("Trail").GetComponent<PlayerStateController>();
        StartCoroutine(DrainCoolDown());
    }
    private void Update()
    {
        
        colorBoundaries();
        onBlueCollect();
        onGreenCollect();
        onRedCollect();
    }
    IEnumerator DrainCoolDown()
    {
        while (true)
        {
            if (playerStateController.getPlayerColor() == Color.red)
            {
                RGBCapacitis[0] -= ammountDrained;
                if (RGBCapacitis[0] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            else if (playerStateController.getPlayerColor() == Color.green)
            {
                RGBCapacitis[1] -= ammountDrained;
                if (RGBCapacitis[1] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            else if (playerStateController.getPlayerColor() == Color.blue)
            {
                RGBCapacitis[2] -= ammountDrained;
                if (RGBCapacitis[2] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
    }
    void colorBoundaries()
    {
        for (int i = 0; i < RGBCapacitis.Length; i++)
        {
            RGBCapacitis[i] = Mathf.Clamp(RGBCapacitis[i],0,maxCapacitis);
        }
    }

    public float getRedCapacitis()
    {
        return RGBCapacitis[0];
    }
    public float getGreenCapacitis()
    {
        return RGBCapacitis[1];
    }
    public float getBlueCapacitis() 
    {
        return RGBCapacitis[2];
    }
    public float getMaxCapacitis() 
    {
        return maxCapacitis;
    }

}
