using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowybackground : MonoBehaviour
{
    Animator animator;
    PlayerStateController trail;
    SpriteGlowEffect backgroundSprite;

    private void Start()
    {
        animator = GetComponent<Animator>();
        trail = GameObject.FindGameObjectWithTag("Trail").GetComponent<PlayerStateController>();
        backgroundSprite = GetComponent<SpriteGlowEffect>();
    }
    public void spread()
    {
        animator.SetTrigger("Change");
    }

    public void changeColor()
    {
        StartCoroutine(startChangeColor());
    }

    private void setColorBackground()
    {
        if (trail.getPlayerColor() == "red")
            backgroundSprite.GlowColor = new Color(1, 0, 0);
        else if (trail.getPlayerColor() == "green")
            backgroundSprite.GlowColor = new Color(0, 1, 0);
        else if (trail.getPlayerColor() == "blue")
            backgroundSprite.GlowColor = new Color(0, 0, 1);
    }

    IEnumerator startChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        setColorBackground();
    }
}
