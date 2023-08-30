using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowybackground : MonoBehaviour
{
    Animator animator;
    TrailRenderer trail;
    SpriteGlowEffect backgroundSprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        trail = GameObject.FindGameObjectWithTag("Trail").GetComponent<TrailRenderer>();
        backgroundSprite = GetComponent<SpriteGlowEffect>();
    }
    public void spread()
    {
        animator.SetTrigger("Change");
    }

    public void changeColor()
    {
        StartCoroutine(delyChangeColor());
    }

    IEnumerator delyChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        backgroundSprite.GlowColor = trail.startColor;
    }
}
