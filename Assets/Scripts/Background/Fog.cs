using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Fog : MonoBehaviour
{
    Renderer fog;
    TrailRenderer trail;
    void Start()
    {
        fog = GetComponent<Renderer>();
        trail = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
    }

    public void changeColor()
    {
        StartCoroutine(delyChangeColor());
    }

    IEnumerator delyChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        fog.sharedMaterial.SetColor("_FogColor", trail.startColor);
    }
}
