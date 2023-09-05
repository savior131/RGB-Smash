using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] Renderer fog;
    [SerializeField] TrailRenderer trail;
    private void Start()
    {
        fog.sharedMaterial.SetColor("_FogColor", new(1, 0, 0));
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
