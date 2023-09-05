using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBackground : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] TrailRenderer trail;
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
