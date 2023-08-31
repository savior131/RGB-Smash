using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ParticleSystemJobs;
public class ColorCollector : MonoBehaviour
{
    PlayerStateController playerStateController;
    
    float[] RGBCapacitis = { 1f, 1f, 1f };
    float amountCollected = 0.01f;
    float ammountDrained = 0.05f;
    [SerializeField] UnityEvent colorChange;
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
        //Debug.Log("red" + RGBCapacitis[0] + " green " + RGBCapacitis[1] + "blue" + RGBCapacitis[2]);
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
            yield return new WaitForSeconds(0.5f);
        }
    }
    void colorBoundaries()
    {
        for (int i = 0; i < RGBCapacitis.Length; i++)
        {
            RGBCapacitis[i] = Mathf.Clamp(RGBCapacitis[i],0,20);
        }
    }

}
