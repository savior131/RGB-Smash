using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBackground : MonoBehaviour
{
    SpriteRenderer sprite;
    TrailRenderer trail;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        trail = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
    }

    public void changeColor()
    {
        StartCoroutine(startChangeColor());
    }
    IEnumerator startChangeColor()
    {
        yield return new WaitForEndOfFrame();
        sprite.color = trail.startColor;
    }
}
