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
        glowyBackground.GlowColor = (glowyBackground.AlphaThreshold < 0.1) ? new(1, 0, 0) : glowyBackground.GlowColor;
    }
}
