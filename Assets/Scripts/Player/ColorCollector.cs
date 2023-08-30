using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
public class ColorCollector : MonoBehaviour
{

    float[] RGBCapacitis = { 1f, 1f, 1f };
    
    public void redCollect()
    {
        RGBCapacitis[0] += 0.1f;
    }
    public void greenCollect()
    {
        RGBCapacitis[1] += 0.1f;
    }
    public void blueCollect()
    {
        RGBCapacitis[2] += 0.1f;
    }
    private void Update()
    {
        Debug.Log("red"+ RGBCapacitis[0]+" green "+ RGBCapacitis[1]+ "blue" + RGBCapacitis[2]);
    }
}

