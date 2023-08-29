using SpriteGlow;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBlueColorState : IPlayerStates
{

    public void colorChange(TrailRenderer newColor, Renderer fog, SpriteRenderer whiteBackground, SpriteGlowEffect glowyBackground, float spreadSpeed, float changeSpeed)
    {
        Color color = Color.Lerp(newColor.startColor, new(0, 0, 1), Time.deltaTime * changeSpeed);
        newColor.startColor = color;
        fog.sharedMaterial.SetColor("_FogColor", color);
        whiteBackground.color = color;
        float interpiolate = Mathf.Abs(Mathf.Lerp(-1f, 1f, Time.deltaTime * spreadSpeed));
        glowyBackground.AlphaThreshold = interpiolate;
        if (interpiolate > -0.01 && interpiolate < 0.1)
        {
            glowyBackground.GlowColor = color;
        }
    }



}
