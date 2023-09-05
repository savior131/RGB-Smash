using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ParticleSystemJobs;
public class ColorCollector : MonoBehaviour
{
    [SerializeField] PlayerStateController playerStateController;
    float maxCapacitis = 5f;
    float[] RGBCapacitis = { 3f, 2.5f, 2.5f };
    float amountCollected = 0.01f;
    float ammountDrained = 0.01f;
    [SerializeField] UnityEvent colorChange;

    public event Action onRedCollect;
    public event Action onGreenCollect;
    public event Action onBlueCollect;
    public void redCollect()
    {
        RGBCapacitis[0] += amountCollected;
        RGBCapacitis[0] = Mathf.Clamp(RGBCapacitis[0], 0, 5);
    }
    public void greenCollect()
    {
        RGBCapacitis[1] += amountCollected;
        RGBCapacitis[1] = Mathf.Clamp(RGBCapacitis[1], 0, 5);
    }
    public void blueCollect()
    {
        RGBCapacitis[2] += amountCollected;
        RGBCapacitis[2] = Mathf.Clamp(RGBCapacitis[2], 0, 5);
    }
    private void Start()
    {
        StartCoroutine(DrainCoolDown());
    }
    private void Update()
    {
        onBlueCollect();
        onGreenCollect();
        onRedCollect();
        //Debug.Log("red" + RGBCapacitis[0] / maxCapacitis + " green " + RGBCapacitis[1] / maxCapacitis + "blue" + RGBCapacitis[2] / maxCapacitis);
    }
    IEnumerator DrainCoolDown()
    {
        while (true)
        {
            if (playerStateController.getPlayerColor() == Color.red)
            {
                RGBCapacitis[0] -= ammountDrained;
                RGBCapacitis[0] = Mathf.Clamp(RGBCapacitis[0], 0, 5);
                if (RGBCapacitis[0] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            else if (playerStateController.getPlayerColor() == Color.green)
            {
                RGBCapacitis[1] -= ammountDrained;
                RGBCapacitis[1] = Mathf.Clamp(RGBCapacitis[1], 0, 5);
                if (RGBCapacitis[1] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            else if (playerStateController.getPlayerColor() == Color.blue)
            {
                RGBCapacitis[2] -= ammountDrained;
                RGBCapacitis[2] = Mathf.Clamp(RGBCapacitis[2], 0, 5);
                if (RGBCapacitis[2] <= 0)
                {
                    colorChange.Invoke();
                }
            }
            yield return new WaitForSeconds(0.05f);
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
