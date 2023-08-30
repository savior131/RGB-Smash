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
        fog.sharedMaterial.SetColor("_FogColor", new(1,0,0));
    }

    public void changeColor()
    {
        StartCoroutine(startChangeColor());
    }

    IEnumerator startChangeColor()
    {
        yield return new WaitForEndOfFrame();
        fog.sharedMaterial.SetColor("_FogColor", trail.startColor);
    }
}
