using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerGreenColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor, Renderer fog, SpriteRenderer whiteBackground, SpriteGlowEffect glowyBackground, float changeSpeed)
    {
        Color color = Color.Lerp(newColor.startColor, new(0, 1, 0), Time.deltaTime* changeSpeed);
        newColor.startColor = color;
        fog.sharedMaterial.SetColor("_FogColor", color);
        whiteBackground.color = color;
        if (glowyBackground.AlphaThreshold < 0.1)
        {
            glowyBackground.GlowColor = new(0, 1, 0);
        }
    }

    public void spread(Animator animator)
    {
        animator.SetTrigger("Change");
    }
}
