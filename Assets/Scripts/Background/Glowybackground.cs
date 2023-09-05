using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glowybackground : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerStateController trail;
    [SerializeField] SpriteGlowEffect backgroundSprite;

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
        if (trail.getPlayerColor() == Color.red)
            backgroundSprite.GlowColor = Color.red;
        else if (trail.getPlayerColor() == Color.green)
            backgroundSprite.GlowColor = Color.green;
        else if (trail.getPlayerColor() == Color.blue)
            backgroundSprite.GlowColor = Color.blue;
    }

    IEnumerator startChangeColor()
    {
        yield return new WaitForSeconds(0.5f);
        setColorBackground();
    }
}
