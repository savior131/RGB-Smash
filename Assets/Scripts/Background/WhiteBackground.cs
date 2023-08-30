using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBackground : MonoBehaviour
{
    SpriteRenderer sprite;
    TrailRenderer trail;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        trail = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
    }

    public void changeColor()
    {
        StartCoroutine(delyChangeColor());
    }

    IEnumerator delyChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        sprite.color = trail.startColor;
    }
}
